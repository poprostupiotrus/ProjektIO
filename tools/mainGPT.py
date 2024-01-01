import re
import time
from gpt import Gpt
from baza import Baza
from funkcje import *

b1=Baza("gpt")
k1 =Gpt()

artykuly = b1.getAll()
for i in artykuly:
    id =i[0]
    article =i[1]+i[2]
    wypisz(id)
    log(i[1])
    try:
        wyniki = k1.zapytajgpt(article)
        wstawionych=0
        for wynik in wyniki:
            try:
                b1.insertNotowanie(IDt1=id,Tickern=wynik[0],notowanie=wynik[1])
                wstawionych+=1
            except Exception as e:
                wypisz(f"blad przy wstawianiu do bazy {id} {wynik} {e}")
                wypisz(f"INSERT INTO gpt( IDt1, Tickern, notowanie) VALUES ({id},'{wynik[0]}',{wynik[1]})")
        if wstawionych >0:
            wypisz("wstawiono artykul")
        elif nieistotnyArtykul(wyniki):
            wypisz("nieistotny artykul")
            b1.insertNotowanie(IDt1=id, Tickern="ALE", notowanie=0)
    except Exception as e:
        wypisz(f'blad przy komunikacj z gpt {e}')
        if "per day (RPD)" in str(e):
            time.sleep(60)
        time.sleep(20)
    time.sleep(5)