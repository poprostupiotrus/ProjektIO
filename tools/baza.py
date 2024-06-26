"""@package docstring
"""
import pymysql
from funkcje import *
class Baza:
    """
    Klasa reprezentująca połączenie z bazą danych MySQL.

    Attributes:
        connection (pymysql.connections.Connection): Połączenie do bazy danych.
        cursor (pymysql.cursors.Cursor): Kursor do bazy danych.
        tabela (str): Nazwa tabeli w bazie danych.
    """

    def __init__(self,tabela):
        """
        cc
        Args:
            tabela:
        """
        """
        Inicjalizuje obiekt Baza z podaną tabelą.

        Args:
            tabela (str): Nazwa tabeli w bazie danych.
        """
        self.connection = pymysql.connect(host="127.0.0.1", port=3306, database="wiadomosci", user="test4", password="123")
        self.cursor = self.connection.cursor()
        self.tabela=tabela

    def getAll(self):
        """
        Pobiera dane z tabeli 't1' spełniające określone kryteria.

        Returns:
            list: Lista krotek zawierających kolumny 'id', 'h1', 'p' z tabeli 't1'.
        """
        self.cursor.execute(f"SELECT id,h1,p FROM t1 where p not like '' and czas BETWEEN '2023-11-07 00:00:00' and '2023-11-15 23:59:59' and id not in(SELECT idt1 from {self.tabela})")
        return self.cursor.fetchall()

    def Query(self,query):
        """
        Wykonuje zapytanie do bazy danych i zatwierdza zmiany.

        Args:
            query (str): Zapytanie SQL.

        Returns:
            None
        """
        self.cursor.execute(query)
        self.connection.commit()

    def insertNotowanie(self,IDt1, Tickern, notowanie):
        """
        Dodaje notowanie do tabeli o nazwie przekazanej podczas inicjalizacji.

        Args:
            IDt1 (int): ID rekordu w tabeli 't1'.
            Tickern (str): Oznaczenie notowanej spółki.
            notowanie (float): Wartość notowania.

        Returns:
            None
        """
        self.cursor.execute(f"INSERT INTO {self.tabela}( IDt1, Tickern, notowanie) VALUES ({IDt1},'{Tickern}',{notowanie})")
        log(f"INSERT INTO {self.tabela}( IDt1, Tickern, notowanie) VALUES ({IDt1},'{Tickern}',{notowanie})")
        self.connection.commit()