from Sledz import Skraper
from baza import Baza
import time
import sys

b1 = Baza("bard")
skrapuj = Skraper()
bledy=0
w1 = b1.getAll()
for i in w1:
    id =i[0]
    article =i[1]+i[2]
    try:
        wyniki = skrapuj.create_query(article)
        blad=0
        bledy=0
        for wynik in wyniki:
            try:
                b1.insertNotowanie(id,wynik[0],wynik[1])
            except:
                print(f"blad przy wstawianiu do bazy {wynik}")
                blad+=1
        if blad < len(wyniki):
            print("wstawiono artykul")
    except Exception as e:
        bledy+=1
        if bledy >3:
            sys.exit(1)
        print(f'przekroczona liczba zapytan {e}')
        time.sleep(20)
