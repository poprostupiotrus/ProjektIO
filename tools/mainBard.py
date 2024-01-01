from Sledz import Skraper
from baza import Baza
import time
import sys
from funkcje import *
b1 = Baza("bard")
skrapuj = Skraper()
bledy=0
w1 = b1.getAll()
for i in w1:
    id =i[0]
    article =i[1]+i[2]
    wypisz(id)
    wypisz(article)
    try:
        wyniki = skrapuj.create_query(article)
        blad=0
        bledy=0
        for wynik in wyniki:
            try:
                b1.insertNotowanie(id,wynik[0],wynik[1])
            except:
                wypisz(f"blad przy wstawianiu do bazy {wynik}")
                blad+=1
        if blad < len(wyniki):
            wypisz("wstawiono artykul")
    except Exception as e:
        bledy+=1
        if bledy >3:
            sys.exit(1)
        wypisz(f'przekroczona liczba zapytan {e}')
        time.sleep(20)
