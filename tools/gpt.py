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
                    """podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20: 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)'
                        Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20, odpowiedź ma być w postaci listy, której elementami są: '<Nazwa spółki> <Notowanie>' i nic, poza tym. Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:                   'JSW +1,25%
                   ALE -1,4%
                   ...'
               Treść artykułu na podstawie którego masz wypisać wyniki:
               """ + article}
            ]
        )
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

