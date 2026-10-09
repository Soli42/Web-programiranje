using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;

namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitController : ControllerBase
{
    public IspitContext Context { get; set; }

    public IspitController(IspitContext context)
    {
        Context = context;
    }
    
    [HttpPost("DodavanjeAnsambla/{Naziv}")]

    public async Task<ActionResult> DodavanjeAnsambla(string Naziv)
    {
        try
        {
            var ans = await Context.Ansambl.Where(p => p.Naziv == Naziv).FirstOrDefaultAsync();
            if(ans != null)
            {
                return BadRequest("Postoji vec takav ansambl!");
            }

            Ansambl ans1 = new Ansambl
            {
                Naziv = Naziv,
                Clanovi = new List<Clanovi>()
            };

            await Context.Ansambl.AddAsync(ans1);
            await Context.SaveChangesAsync();
            return Ok(ans1);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("DodavanjeClana/{idAnsambla}/{Ime}/{Visina}/{BrGodinaIskustva}")]

    public async Task<ActionResult> DodavanjeClana(int idAnsambla, string Ime, int Visina, int BrGodinaIskustva)
    {
        try
        {
            var ansambl = await Context.Ansambl.FindAsync(idAnsambla);
            if(ansambl == null)
            {
                return BadRequest("Ne postoji takav ansambl");
            }
            if(Visina <= 140 || Visina >= 250)
            {
                return BadRequest("Visina nije ispravna");
            }
            if(BrGodinaIskustva < 0 || BrGodinaIskustva > 9)
            {
                return BadRequest("Br godina iskustava nije validan");
            }

            Clanovi clan  = new Clanovi
            {
                Ime = Ime,
                Visina = Visina,
                BrGodineIskustva = BrGodinaIskustva,
                Ansambl = ansambl
            };

            await Context.Clanovi.AddAsync(clan);
            await Context.SaveChangesAsync();
            return Ok(clan);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiAnsamble")]

    public async Task<ActionResult> VratiAnsamble()
    {
        try
        {
            var ansambli = await Context.Ansambl.ToListAsync();
            if(ansambli == null)
            {
                return BadRequest("U listi ne postoje ansambli");
            }
            return Ok(ansambli);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiSortiraneClanove/{idAnsambla}")]

    public async Task<ActionResult> VratiSortiraneClanove(int idAnsambla)
    {
        try
        {
            
            var ans1 = await Context.Ansambl.Where(p => p.ID == idAnsambla)
                                            .Include(p => p.Clanovi).FirstOrDefaultAsync();
            if(ans1 == null || ans1.Clanovi == null)
            {
                return BadRequest("Ne postoji takav ansambl!");
            }

            // var clanovi = ans1.Clanovi.ToList();
            // if (clanovi == null || !lanovi.Any())
            // {
            //     return BadRequest("Ansambl nema članova!");
            // }

            double prosekIskustva = Context.Clanovi.Average(p => p.BrGodineIskustva) / 3.0;

            var kolovodja = await Context.Clanovi.Where(p => p.BrGodineIskustva >= prosekIskustva)
                                                 .OrderByDescending(p => p.Visina)
                                                 .FirstOrDefaultAsync();
            if(kolovodja == null)
            {
                return BadRequest("Ne postoji takav clan/kolovdja");
            }

            var kec = await Context.Clanovi.Where(p => p.BrGodineIskustva >= 2 && p.ID != kolovodja.ID)
                                           .OrderBy(p => p.Visina)
                                           .FirstOrDefaultAsync();
            if(kec == null)
            {
                return BadRequest("Ne postoji kec");
            }

            var ostaliClanovi = await Context.Clanovi.Where(p => p.ID != kec.ID && p.ID != kolovodja.ID)
                                                     .OrderByDescending(p => p.Visina)
                                                     .ToListAsync();
            if(ostaliClanovi == null)
            {
                return BadRequest("Ostali clanovi ne postoje");
            }

            var rezultat = new List<Clanovi>();

            rezultat.Add(kolovodja);

            rezultat.AddRange(ostaliClanovi);

            rezultat.Add(kec);

            return Ok(rezultat);

                                             
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("BrisanjeClana/{idClana}")]

    public async Task<ActionResult> BrisanjeClana(int idClana)
    {
        try
        {
            var clan = await Context.Clanovi.Where(p => p.ID == idClana).FirstOrDefaultAsync();
            if(clan == null)
            {
                return BadRequest("Ne postoji takav clan");
            }

            Context.Clanovi.Remove(clan);
            await Context.SaveChangesAsync();

            return Ok(clan);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
