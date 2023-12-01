import pymysql

class Baza:
    def __init__(self,tabela):
        self.connection = pymysql.connect(host="127.0.0.1", port=3306, database="wiadomosci", user="test4", password="123")
        self.cursor = self.connection.cursor()
        self.tabela=tabela
    def getAll(self):
        self.cursor.execute(f"SELECT id,h1,p FROM t1 where p not like '' and czas BETWEEN '2023-11-07 00:00:00' and '2023-11-15 23:59:59' and id not in(SELECT idt1 from {self.tabela})")
        return self.cursor.fetchall()

    def Query(self,query):
        self.cursor.execute(query)
        self.connection.commit()

    def insertNotowanie(self,IDt1, Tickern, notowanie):
        self.cursor.execute(f"INSERT INTO {self.tabela}( IDt1, Tickern, notowanie) VALUES ({IDt1},'{Tickern}',{notowanie})")
        self.connection.commit()