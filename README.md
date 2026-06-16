# Aplicativo de Exibição de Dados Climáticos

O objetivo desse aplicativo é exibir dados climáticos da cidade especificada no campo de pesquisa.

## Geolocalização (**Geolocation**)

Foi implementada a possibilidade de o usuário utilizar a cidade de sua localização atual, através do botão superior esquerdo, que é rastreada através de sua respectiva latitude e longitude, com recursos de geolocalização nativos do C#.

## Integração de API Externa (**OpenWeather**)

Após o usuário preencher o campo de pesquisa com um valor válido, basta apertar o botão superior direito, que efetuará uma requisição para o serviço do OpenWeather, uma API que disponibiliza dados climáticos do local especificado.

## Mapa (**Windy**)

Com a latitude e longitude retornadas pelo OpenWeather, é renderizado o mapa do site [Windy](https://www.windy.com/), através do componente "WebView" do MAUI, que exibirá, graficamente, dados climáticos da localização especificada.

## Possibilidades Futuras

São retornados muitos outros dados pelo OpenWeather, que também podem ser exibidos na tela do aplicativo em uma adição posterior.
