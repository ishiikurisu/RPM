# Matrizes Progressivas de Raven

Este manual foi escrito pensado no aplicador do teste. Ele descreve como a pasta do aplicativo est� organizada,  como criar um teste e como realizar um teste.


## Estrutura do programa

A pasta do Raven cont�m os seguintes itens:

- Assets: � a pasta que cont�m os testes em si. Todas as imagens e informa��es de um teste dever�o constar aqui.
- Results: � pasta que cont�m os resultados dos testes j� realizados.
- Raven.exe: � o programa.
- README.txt: este arquivo de ajuda que voc� est� lendo.
- FSharp.Core.DLL e Infra.DLL: s�o arquivos necess�rios para que o programa rode.


### Pasta `assets` ###

Nesta pasta, dever�o ser armazenados os arquivos necess�rios para se realizar um teste. Haver� no m�nimo uma pasta chamada `config`, que conter� as informa��es b�sicas dos testes dispon�veis.

Para listar quais testes est�o dispon�veis, adicione um arquivo chamado `versions.txt` dentro desta pasta `config`. Dentro deste arquivo, voc� dever� listar o c�digo do teste (para poder organizar melhor os arquivos) e o nome do teste (para que voc� possa cham�-lo pelo programa). Isso dever� acontecer assim:

```
<c�digo> <Nome do teste>
```

Por exemplo: vamos supor que queremos dois testes: um chamado "Infantil", que ser� codificado por "inf"; e outro chamado "Adulto", identificado por "adl". A vers�o final do arquivo `versions.txt` ficar� assim:

```
inf Infantil
adl Adulto
```

Para cada um destes testes, dever�o haver:

+ Um arquivo `<c�digo>.txt`, contendo o nome das imagens e informa��es sobre elas.
+ Um arquivo `<c�digo>.csv`, contendo uma tabela
+ Uma pasta chamada `<c�digo>`, contendo as imagens do teste.

`TODO write about these files and this folder`.


### Pasta `results` ###

A pasta `results` � onde estar�o listados os arquivos gerados pelo programa ap�s a execu��o de um teste. Estes arquivos s�o tabelas do Excel que podem ser analisadas posteriormente.


## Cria��o de um teste

```
TODO WRITE ABOUT HOW TO CREATE A TEST
```


## Execu��o do programa

```
TODO WRITE ABOUT HOW THE APPLICATION RUNS
```