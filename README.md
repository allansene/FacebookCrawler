# FacebookCrawler
Crawler de facebook em .NET.

# Idéia

A idéia do Facebook Crawler é criar uma interface simples para usuários que queiram fazer consultas a dados públicos pela API do Facebook e baixá-los ou armazená-los em stores ElasticSearch. 

A princípio, tem-se implementados os domínios tipados de 4 tipos de busca.
* Usuários
* Eventos
* Páginas
* Grupos

Os dados são retornados como json e inseridos automaticamente com schema no seu banco ElasticSearch. 
