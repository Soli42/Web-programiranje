using Microsoft.EntityFrameworkCore.Storage;

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
    
    [HttpPost("DodavanjeAutomobila/{Model}/{PredjenaKilometraza}/{Godiste}/{BrSedista}/{CenaPoDanu}/{Iznajmljen}")]
    public async Task<ActionResult> DodavanjeAutomobila(string Model, int PredjenaKilometraza, string Godiste, int BrSedista, int CenaPoDanu, bool Iznajmljen)
    {
        try
        {
             var model = await Context.Automobili.Where(p => p.Model == Model).FirstOrDefaultAsync();
        if(model != null)
        {
            return BadRequest("Postoji takav model");
        }
        
        Automobili auto = new Automobili()
        {
            Model = Model,
            PredjenaKilometraza = PredjenaKilometraza,
            Godiste = Godiste,
            BrSedista = BrSedista,
            CenaPoDanu = CenaPoDanu,
            Iznajmljen = Iznajmljen,
        };

        Context.Automobili.Add(auto);
        await Context.SaveChangesAsync();
        return Ok(auto);
    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("DodavanjeKorisnika/{ImePrezime}/{JMBG}/{BrVozake}")]
    public async Task<ActionResult> DodavanjeKorisnika(string ImePrezime, string JMBG, string BrVozake)
    {
        try
        {
        var jmbg = await Context.Korisnik.Where(p => p.JMBG == JMBG).FirstOrDefaultAsync();
        if(jmbg != null)
        {
            return BadRequest("Postoji takav model");
        }
        
        Korisnik korisnik = new Korisnik()
        {
            ImePrezime = ImePrezime,
            JMBG = JMBG,
            BrVozake = BrVozake
        };

        Context.Korisnik.Add(korisnik);
        await Context.SaveChangesAsync();
        return Ok(korisnik);
    
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiModele")]
    public async Task<ActionResult> VratiModele()
    {
        try
        {
        var model = await Context.Automobili.Select(p => p.Model).Distinct().ToListAsync();
        if(model == null)
        {
            return BadRequest("Prazna lista modela");
        }
        return Ok(model);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiAutomobile")]
    public async Task<ActionResult> VratiAutomobile()
    {
        try
        {
        var auto = await Context.Automobili.ToListAsync();
        if(auto == null)
        {
            return BadRequest("Prazna lista modela");
        }
        return Ok(auto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("IznajmiVozilo/{idAutomobila}/{ImePrezime}/{JMBG}/{BrVozake}/{BrDana}")]
    public async Task<ActionResult> IznajmiVozilo(int idAutomobila, string ImePrezime, string JMBG, string BrVozake, int BrDana)
    {
    
        try
        {
            if(JMBG.Length < 13 || BrVozake.Length < 9)
        {
            return BadRequest("Nevalidan JMBG ili broj vozacke");
        }

        var auto = await Context.Automobili.Where(p => p.ID == idAutomobila).FirstOrDefaultAsync();
        if(auto == null)
        {
            return BadRequest("Ne postoji takav auto!");
        }
            var korisnikIznajmio = await Context.Korisnik.Where(p => p.JMBG == JMBG
                                                        && p.BrVozake == BrVozake).FirstOrDefaultAsync();
            if(korisnikIznajmio == null)
            {
                korisnikIznajmio  = new Korisnik()
                {
                    ImePrezime = ImePrezime,
                    JMBG = JMBG,
                    BrVozake = BrVozake
                };
                await Context.Korisnik.AddAsync(korisnikIznajmio);                
            }

            auto.Iznajmljen = true;

            var spoj = new Spoj()
            {
                // Automobili = new List<Automobili> { auto },
                // Korisnik = new List<Korisnik> { korisnikIznajmio },
                Automobili = auto,
                Korisnik = korisnikIznajmio,
                BrDana = BrDana
            };
            await Context.Spoj.AddAsync(spoj);
            await Context.SaveChangesAsync();
            return Ok(auto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpGet("FiltrirajPrikaz{PredjenaKilometraza}/{BrSedista}/{CenaPoDanu}/{Model}")]

    public async Task<ActionResult> FiltrirajPrikaz(int PredjenaKilometraza, int BrSedista, int CenaPoDanu, string Model)
    {
        try
        {
            if(PredjenaKilometraza != null && BrSedista != null && CenaPoDanu != null && Model != null)
            {
                var auto = await Context.Automobili.Where(p => p.PredjenaKilometraza <= PredjenaKilometraza &&
                                                            p.BrSedista == BrSedista && p.CenaPoDanu <= CenaPoDanu
                                                            && p.Model == Model).ToListAsync();
                if(auto == null)
                {
                    return BadRequest("Ne postoji takvo vozilo");
                }

                return Ok(auto);
            }
            else
            {
                return BadRequest("Nije ispunjen uslov");
            }

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
