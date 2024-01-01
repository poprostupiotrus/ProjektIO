import re
def extract_first_three_letters(string):
    match = re.search(r'(?<![A-Z])[A-Z]{3}(?![A-Z])', string)
    if match and len(match.group(0)) == 3 and match.group(0) != "WIG":
        return match.group(0)
    else:
        return ''

def extract_number(string):
    pattern = r"[-+]?\d+\.?\d*"
    match = re.search(pattern, string)
    if match:
        return float(match.group(0).replace(',','.'))
    else:
        return 0

brakinfo =["Brak wpływu","Nie jestem w stanie","nie jest możliwe","brakuje informacji","Brak informacji","Brak konkretnej informacji","Nie mogę odpowiedzieć","nie zawiera","nie dotyczy","Nie można przewidzieć","Nie ma w podanym artykule informacji","brak powiązania","Brak przewidywań","ogólnikowy","Nie można udzielić","nie pozwala","nie można","nie ma informacji"]

def nieistotnyArtykul(listaa):
    for zmienna in listaa:
        if any(wyraz.lower() in zmienna.lower() for wyraz in brakinfo):
            return True
    return False

def wypisz(nowa_linia):
    try:
        with open("raport2.txt", 'a') as plik:
            plik.write(str(nowa_linia) + '\n')
        print(nowa_linia)
    except Exception as e:
        print(f'Błąd: Nie można zapisać do pliku raport.txt. {e}')

def log(nowa_linia):
    try:
        with open("raport2.txt", 'a') as plik:
            plik.write(str(nowa_linia) + '\n')
    except Exception as e:
        print(f'Błąd: Nie można zapisać do pliku raport.txt. {e}')
