# 🎮 Inclinação de Objetos em Mobile com Aceleração e Calibração

Este repositório contém um projeto desenvolvido como exercício prático para demonstrar o uso da aceleração e calibração de dispositivos móveis em jogos. O objetivo principal é simular a inclinação de objetos com base nos dados de aceleração fornecidos pelo dispositivo, utilizando o Input.acceleration para controlar a rotação de um objeto 3D de forma suave e calibrada.

## 🕹️ Sobre o Projeto 
O projeto simula a rotação de um objeto 3D com base na inclinação do dispositivo, usando dados de aceleração capturados do hardware do dispositivo móvel. O código implementa um sistema de calibração para ajustar os valores de aceleração de modo a garantir uma experiência de controle mais precisa e realista, permitindo que o objeto reaja de maneira fluida e ajustada ao movimento do jogador.

## 🚀 Tecnologias Utilizadas 
- 💻 Linguagem: C#
- 📱 Plataforma: Unity
- ⚙️ Conceitos: Aceleração, Filtro de Suavização, Calibração de Entrada, Movimento de Objetos 3D

## ⚙️ Como Funciona 
- 1️⃣ Aceleração do Dispositivo: O script coleta dados da aceleração do dispositivo utilizando Input.acceleration, que retorna um vetor 3D representando a aceleração do dispositivo nas direções X, Y e Z.
- 2️⃣ Suavização da Aceleração: Um filtro de suavização é aplicado para reduzir a oscilação dos valores e criar uma rotação mais fluida. A aceleração filtrada é combinada com o valor da aceleração anterior.
- 3️⃣ Calibração da Aceleração: A calibração é feita para alinhar os valores de aceleração com a orientação desejada do dispositivo, garantindo que a rotação do objeto esteja correta mesmo em diferentes orientações do dispositivo.
- 4️⃣ Controle de Rotação: A aceleração calibrada é usada para controlar a rotação do objeto, com um fator de escala (maxAngle) para definir a intensidade da rotação. O valor de aceleração ajustado é multiplicado por um valor máximo para limitar a rotação.

## 🎯 Objetivo 
Este projeto visa demonstrar como controlar a inclinação e rotação de objetos em um jogo mobile utilizando os dados de aceleração do dispositivo, com o objetivo de simular um comportamento de controle sensível ao movimento. A calibração e o filtro de suavização são aplicados para garantir uma interação intuitiva e precisa, permitindo que os jogadores controlem os objetos com movimentos naturais do dispositivo.

O projeto foi desenvolvido como parte do exercício de aprendizado sobre como lidar com entradas de dispositivos móveis e implementar sistemas de controle de movimento utilizando aceleração em Unity.
