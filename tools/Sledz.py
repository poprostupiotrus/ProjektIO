import selenium
from time import *
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from funkcje import *
import re


class Skraper:
    def __init__(self):
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
        try:
            self.driver.get(self.bard_url)
            self.driver.implicitly_wait(6)
            input_field = self.driver.find_element(By.CSS_SELECTOR, "#mat-input-0")
            query=query.replace('\t','').replace('\n','').replace('\r','')
            input_field.send_keys(f"podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20: 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)'Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak wedlug ciebie wplynie artyykół na spółki wig20, odpowiedź ma być w postaci tabeli, ktorej elementami sa: '<Nazwa spółki> <Notowanie>' i nic po zatym wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:'JSW +1,25%ALE -1,4%...'Treść artykułu na podstawie którego masz wypisać wyniki: {query}")
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
        self.driver.close()

def getResultTab(response):
    tab = []
    for td_element in response:
        if td_element.text.strip() != '':
            tab.append(td_element.text.strip())
    tab2 = []
    for i in range(0, len(tab), 2):
        tab2.append((extract_first_three_letters(tab[i]), extract_number(tab[i + 1].replace(',','.'))))
    return tab2