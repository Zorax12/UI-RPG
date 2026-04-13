# UI-RPG
## OOP Principi 
<br/>
1: Enkapsulācija: aizsargā kaut kādu informāciju klasē. Šī informācija ir pieejama caur citām metodēm, bet viņu ārpus klases nevar modificēt.Piemēram, Weapons un Magic scriptam minDamage un maxDamage. <br/>
2: Mantošana: Vienā klasē ir sarakstītas kopīgās lietas dažādiem spēles objektiem. Piemēram Enemy klasē ir sarakstīts svarīgākais pretinieku uzvedībai un no tā ņem gan armoredEnemy, fastEnemy, magicEnemy un posionEnemy klases.<br/>
3: Polimorfisms: Viena metode var uzvesties savādāk atkarībā pēc vajadzības. Piemēram katrs Enemy var uzbrukt, bet katrs pretinieka tips uzbrūk nedaudz savādāk, mainot metodes uzvedību.<br/>
4: Abstrakcija: Parāda vispārīgu informāciju, neiedziļinoties pie nevajadzīgā. Piemēram Enemy klase, tiek izmantota pretinieku izsaukšanā, uzbrukuma un trāpijuma došanā. Pretinieku veidu ir daudz, bet svarīgi ir tikai tas ka tie ir "enemy" nevis, piemēram "fast enemy".<br/>

## Papildus uzdevumi
1: Vairogs: Spelētājam ir izvēle starp uzbrukšanu un vairoga izmantošanu. Tiek pievienotas 2 pogas. Defend un repair shield. Defend poga izmanto vairogu, kam ir 100 "dzīvības", pretinieks uzbrūk vairogam kad tas ir aktīvs un parastajām dzīvībām kad tas nav aktīvs. Repair pogai ir 3 charges, kas nedaudz atjauno vairogu. <br/>
<br/>
2: Pretinieki: <br/>
<br/>
Basic enemy: tas ko veidojām skolā<br/>
Armored enemy: Pretiniekam ir papildus "dzīvības" jeb bruņas. Vājšs pret maģiju. <br/>
Fast enemy: Ignorē spēlētāja vairogu. <br/>
Posion enemy: Darbojas tā kā indes duncis, ko veidojām skolā. Ir indes charges, kas dod lielu damage, kad charges iztukšojas, damage ir mazs. <br/>
Magic enemy: Ātri iznīcina vairogu, spēj sev atjaunot hp. <br/>
<br/>
3: Ieroči: <br/>
<br/>
Basic sword: tas, ko veidojām skolā<br/>
Posion weapon: tas, ko veidojām skolā<br/>
Healing staff: uzbrūk pretiniekam un nedaudz atjauno dzīvību<br/>
<br/>
4: Burvestības: <br/>
Tika pievienotas 3 pogas - Cast, switch spell un rejuvenate. Cast - izmanto izvēlēto maģiju. Switch spell - izmaina aktīvo maģiju (tāpat kā ieročiem). Rejuvenate atjauno manu, ko izmanto maģijas izmantošanā.
<br/>
Basic spell: dod damage pretiniekiem.<br/>
Healing spell: atjauno spēlētāja dzīvību<br/>
<br/>
5: Līmeņu sistēma: spēle sākas ar pirmo līmeni, kur ir viens pretinieks. Kad pretinieku uzvar, 2. līmenis ar 2 pretiniekiem. Spēlētāja stats atjaunojas ar katru līmeni
