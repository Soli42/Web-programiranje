export class Automobil{
    constructor(id, model, predjenaKilometraza, godiste, brSedista, cenaPoDanu, iznajmljen){
        this.id = id;
        this.model = model;
        this.predjenaKilometraza = predjenaKilometraza;
        this.godiste = godiste;
        this.brSedista = brSedista;
        this.cenaPoDanu = cenaPoDanu;
        this.iznajmljen = iznajmljen;
        this.kontejner = null;
    }

    crtajAutomobil(host){
        this.kontejner = document.createElement("div");
        this.kontejner.className  = "automobilDiv";
        this.kontejner.style.backgroundColor = this.iznajmljen ? "red" : "green";
        host.appendChild(this.kontejner);

        let podaci = [
            { labela: "Model:", vrednost: this.model},
            { labela: "Kilometraza:", vrednost: this.predjenaKilometraza},
            { labela: "Godiste:", vrednost: this.godiste},
            { labela: "Broj sedista:", vrednost: this.brSedista},
            { labela: "Cena po danu:", vrednost: this.cenaPoDanu},
            { labela: "iznajmljen:", vrednost: this.iznajmljen},

        ];

        for(const p of podaci){
            let redDiv = document.createElement("div");
            redDiv.className = "redDiv";
            this.kontejner.appendChild(redDiv);

            let levaLabela = document.createElement("label");
            levaLabela.className = "levaLabela";
            levaLabela.innerHTML = p.labela;
            redDiv.appendChild(levaLabela);

            let desnaLabela = document.createElement("label");
            desnaLabela.className = "desnaLabela";
            desnaLabela.innerHTML = p.vrednost;
            redDiv.appendChild(desnaLabela);
        }

        
            let dugmeIznajmi = document.createElement("button");
            dugmeIznajmi.className = "dugmeIznajmi";
            dugmeIznajmi.innerHTML = "Iznajmi";
            if(this.iznajmljen){
                dugmeIznajmi.disabled = true;
            }
            dugmeIznajmi.onclick = async (ev) => this.iznajmi();
            this.kontejner.appendChild(dugmeIznajmi);
 

        
    }

    async iznajmi(){
        try{
            let imeprezime = document.querySelector(".leviInput1").value;
            let jmbgg = document.querySelector(".leviInput2").value;
            let brVoz = document.querySelector(".leviInput3").value;
            let brD = document.querySelector(".leviInput4").value;

            if(imeprezime === "" || jmbgg === "" || brVoz === "" || brD === ""){
                alert("Nisu popunjena sva polja");
                return;
            }

            const response = await fetch(`https://localhost:7080/Ispit/IznajmiVozilo/${this.id}/${imeprezime}/${jmbgg}/${brVoz}/${brD}`,
                {method: "PUT"}
            );

                this.iznajmljen = true;


            const podaci = await response.json();
            for(const p of podaci){
                
                let d = this.kontejner.querySelector(".dugmeIznajmi");
                dugmeIznajmi.disabled = true;
                this.kontejner.style.backgroundColor = "red";

                if(this.iznajmljen){ 
                    this.iznajmljen.innerHTML = "true";
                }
                alert("Vozilo je uspesno iznajmljeno");
            }


        }
        catch (error){
            console.error(error);
        }
    }

}