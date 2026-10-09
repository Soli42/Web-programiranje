import { Clanovi } from "./Clanovi.js";

export class Ansambl{
    constructor(id, naziv){
        this.id = id;
        this.naziv = naziv;
        this.kontejner = null;
        this.listaIskustvo = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        this.prikazClanovaDiv = null;
    }


    async crtajAplikaciju(){
        this.kontejner = document.createElement("div");
        this.kontejner.className = "glavniDiv";
        document.body.appendChild(this.kontejner);

        let ansamblDiv = document.createElement("div");
        ansamblDiv.className = "ansamblDiv";
        this.kontejner.appendChild(ansamblDiv);

        let ansamblLabela = document.createElement("label");
        ansamblLabela.className = "ansamblLabela";
        ansamblLabela.innerHTML = this.naziv;
        ansamblDiv.appendChild(ansamblLabela);



        let clanoviDiv = document.createElement("div");
        clanoviDiv.className = "clanoviDiv";
        this.kontejner.appendChild(clanoviDiv);

        this.prikazClanovaDiv = document.createElement("div");
        this.prikazClanovaDiv.className = "prikazClanovaDiv";
        clanoviDiv.appendChild(this.prikazClanovaDiv);

        let meniDiv = document.createElement("div");
        meniDiv.className = "meniDiv";
        clanoviDiv.appendChild(meniDiv);

        let dodajClanaLabela = document.createElement("label");
        dodajClanaLabela.className = "dodajClanaLabela";
        dodajClanaLabela.innerHTML = "Dodaj clana";
        meniDiv.appendChild(dodajClanaLabela);

        let imeDiv = document.createElement("div");
        imeDiv.className = "imeDiv";
        meniDiv.appendChild(imeDiv);

        let imeLabela = document.createElement("label");
        imeLabela.className = "imeLabela";
        imeLabela.innerHTML = "Ime";
        imeDiv.appendChild(imeLabela);

        let inputIme = document.createElement("input");
        inputIme.className =  "inputIme";
        inputIme.type = "text";
        imeDiv.appendChild(inputIme);


        let visinaDiv = document.createElement("div");
        visinaDiv.className = "visinaDiv";
        meniDiv.appendChild(visinaDiv);

        let visinaLabela = document.createElement("label");
        visinaLabela.className = "visinaLabela";
        visinaLabela.innerHTML = "Visina";
        visinaDiv.appendChild(visinaLabela);

        let inputVisina = document.createElement("input");
        inputVisina.className =  "inputVisina";
        inputVisina.type = "number";
        visinaDiv.appendChild(inputVisina);


        let iskustvoDiv = document.createElement("div");
        iskustvoDiv.className = "iskustvoDiv";
        meniDiv.appendChild(iskustvoDiv);

        let iskustvoLabela = document.createElement("label");
        iskustvoLabela.className = "iskustvoLabela";
        iskustvoDiv.appendChild(iskustvoLabela);

        let iskustvoSelect = document.createElement("select");
        iskustvoSelect.className =  "iskustvoSelect";
        iskustvoDiv.appendChild(iskustvoSelect);

        for(const i of this.listaIskustvo){
            let opcija = document.createElement("option");
            opcija.className = "opcija";
            opcija.innerHTML = i;
            opcija.value = i;
            iskustvoSelect.appendChild(opcija);
        }

        let dugmeDodaj = document.createElement("button");
        dugmeDodaj.className = "dugmeDodaj";
        dugmeDodaj.innerHTML = "Dodaj clana";
        dugmeDodaj.onclick = async (ev) => await this.dodajClana();
        meniDiv.appendChild(dugmeDodaj);



        let listaClanovaDiv = document.createElement("div");
        listaClanovaDiv.className = "listaClanovaDiv";
        clanoviDiv.appendChild(listaClanovaDiv);

        await this.prikaziClanove();
    }

    async prikaziClanove(){
        try{
            this.prikazClanovaDiv.innerHTML = "";
            const response = await fetch(`https://localhost:7080/Ispit/VratiSortiraneClanove/${this.id}`, {
                method: "GET"
            });
            if(!response.ok){
                alert("Problem sa povezivanjem baze");
                return;
            }
            const podaci = await response.json();
            podaci.forEach((p, index) => {
                let c = new Clanovi(p.id, p.ime, p.visina, p.brGodinaIskustva, () => this.prikaziClanove());

                let kockicaDiv = c.crtajClana(this.prikazClanovaDiv);

                if(index == 0){
                    kockicaDiv.classList.add("kolovodja");
                }
                else if(index == podaci.length - 1){
                    kockicaDiv.classList.add("kec");
                }
                else{
                    kockicaDiv.classList.add("ostaliClanovi");
                }
            });
        }
        catch (error){
            console.error(error);
        }
    }


    async dodajClana(){
        try{
            let ime = document.querySelector(".inputIme").value;
            let visina = document.querySelector(".inputVisina").value;
            let iskustvo = document.querySelector("select").value;

            if(!ime || !visina){
                alert("Unesi sva polja");
                return;
            }
            const response = await fetch(`https://localhost:7080/Ispit/DodavanjeClana/${this.id}/${ime}/${visina}/${iskustvo}`, {
                method: "POST"
            });

            if(response.ok){
                await this.prikaziClanove();
            }
        }
        catch (error){
            console.error(error);
        }
    }
}