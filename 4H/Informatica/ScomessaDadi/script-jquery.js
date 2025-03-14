// Antonio De Rosa 4H - Scommessa Dadi - 21/02/2025
let saldo = 500;
let puntata = 0;

function getDiceNumber() {
    let dado1 = Math.floor(Math.random() * 6) + 1;
    let dado2 = Math.floor(Math.random() * 6) + 1;
    return dado1 + dado2;
}

function play() {
    puntata = parseInt($("#puntata").val());
    if (puntata > saldo) {
        alert("Non hai abbastanza soldi per puntare questa cifra");
        return;
    }
    if (puntata < 1) {
        alert("Devi puntare almeno 1 euro");
        return;
    }
    
    saldo -= puntata;
    let diceNumber = getDiceNumber();
    
    let scommessa = parseInt($("#scommessa").val());
    if (scommessa < 2 || scommessa > 12) {
        alert("La scommessa deve essere compresa tra 2 e 12");
        return;
    }
    
    if (scommessa == diceNumber) {
        saldo += puntata * 2;
        $("#risultato").text("Hai vinto! Il numero uscito è " + diceNumber);
    } else {
        $("#risultato").text("Hai perso! Il numero uscito è " + diceNumber);
    }
    
    $("#saldo").text("Il tuo saldo è: " + saldo);
}