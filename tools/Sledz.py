"""@package docstring
"""
import selenium
from time import *
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from funkcje import *
import re


class Skraper:
    """
    @brief Klasa reprezentująca skraper dla strony bard.google.com/chat.

    @var bard_url: Adres URL strony Bard.
    @var options: Opcje konfiguracyjne dla przeglądarki.
    @var driver: Obiekt przeglądarki Chrome.
    """
    def __init__(self):
        """
        Inicjalizuje obiekt Skraper i otwiera przeglądarkę Chrome.
        """
        self.bard_url = "https://bard.google.com/chat"

        self.options = Options()
        # Wyłącz wysyłanie nagłówków
        self.options.headless = True
        self.options.add_argument("--disable-blink-features=AutomationControlled")
        self.options.add_argument("--disable-infobars")
        self.driver = webdriver.Chrome(options=self.options)
        self.driver.get(self.bard_url)
        a = input("podaj a: ")

    def create_query(self,query):
        """
        Tworzy zapytanie na stronie Bard i zwraca wyniki jako tabelę.

        Args:
            query (str): Treść artykułu na podstawie którego ma być stworzone zapytanie.

        Returns:
            list: Lista krotek zawierających nazwę spółki i przewidywanie.
        """
        try:
            self.driver.get(self.bard_url)
            self.driver.implicitly_wait(6)
            input_field = self.driver.find_element(By.CSS_SELECTOR, "#mat-input-0")
            query=query.replace('\t','').replace('\n','').replace('\r','')
            input_field.send_keys(f"Indeks WIG20 jest indeksem cenowym największych spółek giełdowych w Polsce. Wartość indeksu obliczana jest na podstawie obrotów i cen akcji 20 spółek giełdowych.podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20: 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)' Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20, odpowiedź ma być w postaci tabeli, ktorej elementami sa: '<Nazwa spółki> <Przewidywanie>' i nic, poza tym(przewidywanie liczba z przedzialu <-10;10> gdzie -10 to wysokie prawdopodobienstwo spatku notowania danej spółki, 10-wysokie prawdopodobieństwo ze artykuł wplynie pozytywnie na notowania spolki,Nazwa spółki- trzyliterowy TICKERN spolki). Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:'JSW -1ALE +4...'Treść artykułu na podstawie którego masz wypisać wyniki: {query}")
            sleep(3)
            input_field.send_keys(Keys.ENTER)
            #self.driver.find_element(By.CSS_SELECTOR,".send-button").click()

            # Poczekaj, aż odpowiedź zostanie wyświetlona
            sleep(8)
            self.driver.implicitly_wait(8)
            response = self.driver.find_elements(By.CSS_SELECTOR, "tbody td")

            return getResultTab(response)
        except Exception as e:
            print(f"blad {e}")

    def __del__(self):
        """
        @brief Zamyka przeglądarkę Chrome po zniszczeniu obiektu Skraper.
        """
        self.driver.close()

def getResultTab(response):
    """
    Przetwarza elementy response na listę tupli.

    Args:
        response (list): Lista elementów HTML reprezentujących wyniki zapytania.

    Returns:
        list: Lista krotek zawierających nazwę spółki i przewidywanie.
    """
    tab = []
    for td_element in response:
        if td_element.text.strip() != '':
            log(td_element.text.strip())
            tab.append(td_element.text.strip())
    tab2 = []
    for i in range(0, len(tab), 2):
        tab2.append((extract_first_three_letters(tab[i]), extract_number(tab[i + 1].replace(',','.'))))
    return tab2