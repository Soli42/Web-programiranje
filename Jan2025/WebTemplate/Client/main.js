import { Korisnik } from "./Korisnik.js";
import { Automobil } from "./Automobil.js";

let kontejner = null;

async function pokreniAplikaciju(){
    await crtajAplikaciju();
}
async function crtajAplikaciju(){
        try{
        kontejner = document.createElement("div");
        kontejner.className = "kontejner"
        document.body.appendChild(kontejner);

        let leviDiv = document.createElement("div");
        leviDiv.className = "leviDiv";
        kontejner.appendChild(leviDiv);

        let desniDiv = document.createElement("div");
        desniDiv.className = "desniDiv";
        kontejner.appendChild(desniDiv);

        let leviGornji = document.createElement("div");
        leviGornji.className = "leviGornji";
        leviDiv.appendChild(leviGornji);

        let leviDonji = document.createElement("div");
        leviDonji.className = "leviDonji";
        leviDiv.appendChild(leviDonji);

        let leviGornji1 = document.createElement("div");
        leviGornji1.className = "leviGornji1";
        leviGornji.appendChild(leviGornji1);

        let levaLabela1 = document.createElement("label");
        levaLabela1.className = "levaLabela1";
        levaLabela1.innerHTML = "Ime i prezime:";
        leviGornji1.appendChild(levaLabela1);

        let leviInput1 = document.createElement("input");
        leviInput1.className = "leviInput1";
        leviInput1.type = "text";
        leviGornji1.appendChild(leviInput1);

        let leviGornji2 = document.createElement("div");
        leviGornji2.className = "leviGornji2";
        leviGornji.appendChild(leviGornji2);

         let levaLabela2 = document.createElement("label");
        levaLabela2.className = "levaLabela2";
        levaLabela2.innerHTML = "JMBG:";
        leviGornji2.appendChild(levaLabela2);

        let leviInput2 = document.createElement("input");
        leviInput2.className = "leviInput2";
        leviInput2.type = "text";
        leviGornji2.appendChild(leviInput2);

        let leviGornji3 = document.createElement("div");
        leviGornji3.className = "leviGornji3";
        leviGornji.appendChild(leviGornji3);

         let levaLabela3 = document.createElement("label");
        levaLabela3.className = "levaLabela3";
        levaLabela3.innerHTML = "Broj vozacke dozvole:";
        leviGornji3.appendChild(levaLabela3);

        let leviInput3 = document.createElement("input");
        leviInput3.className = "leviInput3";
        leviInput3.type = "text";
        leviGornji3.appendChild(leviInput3);


        let leviGornji4 = document.createElement("div");
        leviGornji4.className = "leviGornji4";
        leviGornji.appendChild(leviGornji4);

        let levaLabela4 = document.createElement("label");
        levaLabela4.className = "levaLabela4";
        levaLabela4.innerHTML = "Broj dana:";
        leviGornji4.appendChild(levaLabela4);

        let leviInput4 = document.createElement("input");
        leviInput4.className = "leviInput4";
        leviInput4.type = "text";
        leviGornji4.appendChild(leviInput4);


        let leviDonji1 = document.createElement("div");
        leviDonji1.className = "leviDonji1";
        leviDonji.appendChild(leviDonji1);

         let levaDonjaLabela1 = document.createElement("label");
        levaDonjaLabela1.className = "levaDonjaLabela1";
        levaDonjaLabela1.innerHTML = "Predjena kilometraza:";
        leviDonji1.appendChild(levaDonjaLabela1);

        let desniDonjiInput1 = document.createElement("input");
        desniDonjiInput1.className = "desniDonjiInput1";
        desniDonjiInput1.type = "text";
        leviDonji1.appendChild(desniDonjiInput1);

        let leviDonji2 = document.createElement("div");
        leviDonji2.className = "leviDonji2";
        leviDonji.appendChild(leviDonji2);

        let levaDonjaLabela2 = document.createElement("label");
        levaDonjaLabela2.className = "levaDonjaLabela2";
        levaDonjaLabela2.innerHTML = "Broj sedista:";
        leviDonji2.appendChild(levaDonjaLabela2);

        let desniDonjiInput2 = document.createElement("input");
        desniDonjiInput2.className = "desniDonjiInput2";
        desniDonjiInput2.type = "text";
        leviDonji2.appendChild(desniDonjiInput2);

        let leviDonji3 = document.createElement("div");
        leviDonji3.className = "leviDonji3";
        leviDonji.appendChild(leviDonji3);

        let levaDonjaLabela3 = document.createElement("label");
        levaDonjaLabela3.className = "levaDonjaLabela3";
        levaDonjaLabela3.innerHTML = "Cena:";
        leviDonji3.appendChild(levaDonjaLabela3);

        let desniDonjiInput3 = document.createElement("input");
        desniDonjiInput3.className = "desniDonjiInput3";
        desniDonjiInput3.type = "text";
        leviDonji3.appendChild(desniDonjiInput3);

        let leviDonji4 = document.createElement("div");
        leviDonji4.className = "leviDonji4";
        leviDonji.appendChild(leviDonji4);

        let levaDonjaLabela4 = document.createElement("label");
        levaDonjaLabela4.className = "levaDonjaLabela4";
        levaDonjaLabela4.innerHTML = "Model:";
        leviDonji4.appendChild(levaDonjaLabela4);

        let desniDonjiSelect = document.createElement("select");
        desniDonjiSelect.className = "desniDonjiSelect";
        leviDonji4.appendChild(desniDonjiSelect);

        let dugmeFiltriraj = document.createElement("button");
        dugmeFiltriraj.className = "dugmeFiltriraj";
        dugmeFiltriraj.innerHTML  = "Filtriraj prikaz";
        dugmeFiltriraj.onclick = async (ev) => await filtriraj();
        leviDonji.appendChild(dugmeFiltriraj);
        const response = await fetch("https://localhost:7080/Ispit/VratiModele");
        if(!response.ok){
            alert("Greska pri povlacenju podataka");
            return;
        }
        const mod = await response.json();

        for(const m of mod){
            let opcija = document.createElement("option");
            opcija.innerHTML = m;
            opcija.value = m;
            desniDonjiSelect.appendChild(opcija);
        }
        }
        catch (error){
            console.error(error);
        }

        try{
            let desniDiv = document.querySelector(".desniDiv");
            desniDiv.innerHTML = "";
            let automobili = [];

            const response = await fetch("https://localhost:7080/Ispit/VratiAutomobile");

            if(!response.ok){
                alert("Greska pri povlacenju podataka");
                return;
            }

            const auto = await response.json();

            for(const a of auto){
                automobili.push(new Automobil(a.id, a.model, a.predjenaKilometraza, a.godiste, a.brSedista, a.cenaPoDanu, a.iznajmljen));
            }

            for(const a of automobili){
                a.crtajAutomobil(desniDiv);
            }
        }
        catch (error){
            console.error(error);
        }
    
}



async function filtriraj() {
    let prKilom = kontejner.querySelector(".desniDonjiInput1").value;
    let brSed = kontejner.querySelector(".desniDonjiInput2").value;
    let cena = kontejner.querySelector(".desniDonjiInput3").value;
    let model = kontejner.querySelector("select");
    const mmodel = model.options[model.selectedIndex].value;

    let autici = [];
    let desniDiv = kontejner.querySelector(".desniDiv");
    desniDiv.innerHTML = "";

    if(prKilom === "" || brSed === "" || cena === "" || mmodel === ""){
        alert("Nisu popunjena sva polja");
        return;
    }

    try{
        const response = await fetch(`https://localhost:7080/Ispit/FiltrirajPrikaz/${prKilom}/${brSed}/${cena}/${mmodel}`, {
            method: "GET"
        });

        if(!response.ok){
            alert("Greska kod povlacenja podataka");
            return;
        }

        const vracenNiz = await response.json();

        for(const v of vracenNiz){
            autici.push(new Automobil(v.id, v.model, v.predjenaKilometraza, v.godiste, v.brSedista, v.cenaPoDanu, v.iznajmljen));
        }

        for(const a of autici){
            a.crtajAutomobil(desniDiv);
        }
    }
    catch (error){
        console.error(error);
    }
}


pokreniAplikaciju();