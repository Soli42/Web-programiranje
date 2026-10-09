export class Clanovi{
    constructor(id, ime, visina, brGodinaIskustva, callbackFunkcija){
        this.id = id;
        this.ime = ime;
        this.visina = visina;
        this.brGodinaIskustva = brGodinaIskustva;
        this.callbackFunkcija = callbackFunkcija;
        
    }


     crtajClana(host){
        let kockicaClan = document.createElement("div");
        kockicaClan.className = "kockicaClan";

        let kockicaLabelaIme = document.createElement("label");
        kockicaLabelaIme.className = "kockicaLabelaIme";
        kockicaLabelaIme.innerHTML = this.ime;
        kockicaClan.appendChild(kockicaLabelaIme);

        let kockicaLabelaVisina = document.createElement("label");
        kockicaLabelaVisina.className = "kockicaLabelaVisina";
        kockicaLabelaVisina.innerHTML = this.visina;
        kockicaClan.appendChild(kockicaLabelaVisina);

        kockicaClan.onclick = async () => {
            try{
                const response = await fetch(`https://localhost:7080/Ispit/BrisanjeClana/${this.id}`, {
                    method: "DELETE"
                });

                if(response.ok){
                    this.callbackFunkcija();
                }
            }
            catch (error){
                console.error(error);
            }
        }

        host.appendChild(kockicaClan);

        return kockicaClan;

    }
}