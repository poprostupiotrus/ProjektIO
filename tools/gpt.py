from openai import OpenAI
from funkcje import *
class Gpt:
    def __init__(self):
        self.client = OpenAI(api_key='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', )
        self.kolejka = ["gpt-3.5-turbo", "gpt-3.5-turbo-0301", "gpt-3.5-turbo-0613", "gpt-3.5-turbo-1106","gpt-3.5-turbo-16k"]

    def getGptResponse(self,article):
        completion = self.client.chat.completions.create(
            model=self.pobierz_element(),
            messages=[
                {"role": "system", "content":
                    """Indeks WIG20 jest indeksem cenowym największych spółek giełdowych w Polsce. Wartość indeksu obliczana jest na podstawie obrotów i cen akcji 20 spółek giełdowych.podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20:
 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)' 
 Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20,  odpowiedź ma być w postaci listy, której elementami są: '<Nazwa spółki> <Przewidywanie>' i nic, poza tym(przewidywanie liczba z przedzialu <-10;10> gdzie -10 to wysokie prawdopodobienstwo spatku notowania danej spółki, 
 10-wysokie prawdopodobieństwo ze artykuł wplynie pozytywnie na notowania spolki,Nazwa spółki- trzyliterowy TICKERN spolki). Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:
'JSW -1
ALE +4
...'
Treść artykułu na podstawie którego masz wypisać wyniki:
               """ + article}
            ]
        )
        log(completion.choices[0].message.content)
        return completion.choices[0].message.content

    def zapytajgpt(self,art):
        lista = []
        wynik = self.getGptResponse(art).split('\n')
        print(wynik)
        for line in wynik:
            liczba2 = extract_number(line.replace(',', '.'))
            if "wzrost" in line:
                liczba2 = abs(liczba2)
            if "spadek" in line:
                liczba2 = -abs(liczba2)
            lista.append((extract_first_three_letters(line.strip()), liczba2))
        return lista
    def pobierz_element(self):
        if self.kolejka:
            element = self.kolejka.pop(0)
            self.kolejka.append(element)
            return element
        else:
            print("Kolejka jest pusta.")

