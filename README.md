# README.md

# Top Down Shooter Game

Este é um jogo 2D do tipo top-down shooter com elementos roguelike. O jogo permite que os jogadores controlem um personagem que deve enfrentar inimigos e sobreviver em um ambiente dinâmico.

## Estrutura do Projeto

O projeto contém os seguintes componentes principais:

- **Scripts**: Contém a lógica do jogo, incluindo controle do jogador, IA dos inimigos e gerenciamento de armas.
- **Prefabs**: Prefabs para o jogador, inimigos e projéteis.
- **Cenas**: A cena principal do jogo onde a ação acontece.
- **ScriptableObjects**: Dados configuráveis sobre as armas.

## Instruções para Montar a Cena no Unity

1. **Objetos necessários**: Crie os objetos `Player`, `Enemy`, `FirePoint` (ponto de disparo para as balas).
2. **Componentes a adicionar**: Adicione `Rigidbody2D` e `Collider` aos objetos `Player` e `Enemy`. Adicione os scripts correspondentes a cada objeto.
3. **Como criar os prefabs**: Arraste os objetos da cena para a pasta `Prefabs` para criar os prefabs.
4. **Como configurar tags e layers**: Selecione os objetos e configure as tags como "Player" e "Enemy" nas propriedades do Inspector.
5. **Configuração básica da câmera**: Ajuste a câmera para seguir o jogador, utilizando um script de câmera ou configurando manualmente.