import { Clanovi } from "./Clanovi.js";
import { Ansambl } from "./Ansambl.js";

async function pokreniAplikaciju() {
    try{
        const response = await fetch("https://localhost:7080/Ispit/VratiAnsamble", {
            method: "GET"
        });
         if(!response.ok){
                alert("Problem sa povezivanjem baze");
                return;
            }
        const podaci = await response.json();
        for(const p of podaci){
            let ansambl = new Ansambl(p.id, p.naziv);
            ansambl.crtajAplikaciju();
        }
    }
    catch (error){
        console.error(error);
    }


}
pokreniAplikaciju();