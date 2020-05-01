using System;
using System.Text.RegularExpressions;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");

            string[,] matriz = new string[9, 9]; // Matriz principal que armazenará os dados do campoMinado.Tabuleiro()

            void preencherCampo()
            {
                string NewNumeros = Regex.Replace(campoMinado.Tabuleiro, @"\t|\n|\r", "");

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        matriz[i, j] = NewNumeros[j].ToString();
                    }
                    NewNumeros = NewNumeros.Remove(0, 9);
                }
            } // Preenche a Matriz com os dados do campoMinado.Tabuleiro
            preencherCampo();

            string[,] frente = new string[2, 3]; // Arrays para guardarem posições e valores das celulas adjacentes da matriz selecionada
            string[,] costas = new string[2, 3];
            string[,] cima = new string[2, 3];
            string[,] baixo = new string[2, 3];
            string[,] diagonalCimaAtras = new string[2, 3];
            string[,] diagonalCimaFrente = new string[2, 3];
            string[,] diagonalBaixoAtras = new string[2, 3];
            string[,] diagonalBaixoFrente = new string[2, 3];

            int[] posicaoInical = new int[2]; // Pega a posição selecionada da Matriz 

            void LinhaseColunasCasaSelecionada(int i, int j)
            {
                for (int k = 0; k < 1; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        frente[k, l] = null;
                        costas[k, l] = null;
                        cima[k, l] = null;
                        baixo[k, l] = null;
                        diagonalCimaAtras[k, l] = null;
                        diagonalCimaFrente[k, l] = null;
                        diagonalBaixoAtras[k, l] = null;
                        diagonalBaixoFrente[k, l] = null;
                    }

                } // preenche os arrays com valores nulos para que não fiquem dados de consultas anteriores 

                if (i != 0)
                {
                    cima[0, 0] = matriz[i - 1, j];
                    cima[0, 1] = (i - 1).ToString();
                    cima[0, 2] = (j).ToString();
                } // Impede que o índice fique fora dos limites da matriz

                if (j != 0)
                {
                    costas[0, 0] = matriz[i, j - 1];
                    costas[0, 1] = (i).ToString();
                    costas[0, 2] = (j - 1).ToString();
                }

                if (i != 8)
                {
                    baixo[0, 0] = matriz[i + 1, j];
                    baixo[0, 1] = (i + 1).ToString();
                    baixo[0, 2] = (j).ToString();
                }

                if (j != 8)
                {
                    frente[0, 0] = matriz[i, j + 1];
                    frente[0, 1] = (i).ToString();
                    frente[0, 2] = (j + 1).ToString();
                }

                if (i != 0 && j != 0)
                {
                    diagonalCimaAtras[0, 0] = matriz[i - 1, j - 1];
                    diagonalCimaAtras[0, 1] = (i - 1).ToString();
                    diagonalCimaAtras[0, 2] = (j - 1).ToString();
                }

                if (i != 8 && j != 8)
                {
                    diagonalBaixoFrente[0, 0] = matriz[i + 1, j + 1];
                    diagonalBaixoFrente[0, 1] = (i + 1).ToString();
                    diagonalBaixoFrente[0, 2] = (j + 1).ToString();
                }

                if (i != 0 && j != 8)
                {
                    diagonalCimaFrente[0, 0] = matriz[i - 1, j + 1];
                    diagonalCimaFrente[0, 1] = (i - 1).ToString();
                    diagonalCimaFrente[0, 2] = (j + 1).ToString();
                }

                if (i != 8 && j != 0)
                {
                    diagonalBaixoAtras[0, 0] = matriz[i + 1, j - 1];
                    diagonalBaixoAtras[0, 1] = (i + 1).ToString();
                    diagonalBaixoAtras[0, 2] = (j - 1).ToString();
                }

                numerosAoLado(); // Chama essa função para verificar se aciona ou não a função preencherCampo()
            } // Preenche um Grupo de Arrays com as posições e valores das celulas adjacentes a celula fornecida

            void LinhaseColunasCasaSelecionadaAoLado(int i, int j)
            {
                for (int k = 1; k < 2; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        frente[k, l] = null;
                        costas[k, l] = null;
                        cima[k, l] = null;
                        baixo[k, l] = null;
                        diagonalCimaAtras[k, l] = null;
                        diagonalCimaFrente[k, l] = null;
                        diagonalBaixoAtras[k, l] = null;
                        diagonalBaixoFrente[k, l] = null;
                    }

                } // preenche os arrays com valores nulos para que não fiquem dados de consultas anteriores 

                if (i != 0) // Impede que o índice fique fora dos limites da matriz
                {
                    cima[1, 0] = matriz[i - 1, j];
                    cima[1, 1] = (i - 1).ToString();
                    cima[1, 2] = (j).ToString();
                }

                if (j != 0)
                {
                    costas[1, 0] = matriz[i, j - 1];
                    costas[1, 1] = (i).ToString();
                    costas[1, 2] = (j - 1).ToString();
                }

                if (i != 8)
                {
                    baixo[1, 0] = matriz[i + 1, j];
                    baixo[1, 1] = (i + 1).ToString();
                    baixo[1, 2] = (j).ToString();
                }

                if (j != 8)
                {
                    frente[1, 0] = matriz[i, j + 1];
                    frente[1, 1] = (i).ToString();
                    frente[1, 2] = (j + 1).ToString();
                }

                if (i != 0 && j != 0)
                {
                    diagonalCimaAtras[1, 0] = matriz[i - 1, j - 1];
                    diagonalCimaAtras[1, 1] = (i - 1).ToString();
                    diagonalCimaAtras[1, 2] = (j - 1).ToString();
                }

                if (i != 8 && j != 8)
                {
                    diagonalBaixoFrente[1, 0] = matriz[i + 1, j + 1];
                    diagonalBaixoFrente[1, 1] = (i + 1).ToString();
                    diagonalBaixoFrente[1, 2] = (j + 1).ToString();
                }

                if (i != 0 && j != 8)
                {
                    diagonalCimaFrente[1, 0] = matriz[i - 1, j + 1];
                    diagonalCimaFrente[1, 1] = (i - 1).ToString();
                    diagonalCimaFrente[1, 2] = (j + 1).ToString();
                }

                if (i != 8 && j != 0)
                {
                    diagonalBaixoAtras[1, 0] = matriz[i + 1, j - 1];
                    diagonalBaixoAtras[1, 1] = (i + 1).ToString();
                    diagonalBaixoAtras[1, 2] = (j - 1).ToString();
                }
            } // Preenche um Grupo de Arrays com as posições e valores das celulas adjacentes a celula adjacente extraida

            int ContarTracinhosAdjacentes()
            {
                int num = 0; // Contador de tracinhos adjacentes

                if (frente[1, 0] == "-")
                {
                    num++;
                }
                if (costas[1, 0] == "-")
                {
                    num++;
                }
                if (cima[1, 0] == "-")
                {
                    num++;
                }
                if (baixo[1, 0] == "-")
                {
                    num++;
                }
                if (diagonalCimaAtras[1, 0] == "-")
                {
                    num++;
                }
                if (diagonalCimaFrente[1, 0] == "-")
                {
                    num++;
                }
                if (diagonalBaixoAtras[1, 0] == "-")
                {
                    num++;
                }
                if (diagonalBaixoFrente[1, 0] == "-")
                {
                    num++;
                }
                return num;
            } // Contar tracinhos da celula da matriz fornecida

            void numerosAoLado()
            {
                if (cima[0, 0] == "1")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(cima[0, 1]), int.Parse(cima[0, 2])); // Preenche um Grupo de Arrays com as posições e valores das celulas adjacentes a celula adjacente extraida
                    int num = ContarTracinhosAdjacentes(); // Contagem dos tracinhos adjacentes para analisar se aciona ou não o campoMinado.Abrir()

                    if (num > 1) // Caso o numero da contagem de tracinhos seja maior que 1 ela abre a celula selecionada, se não não abre
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                } // Verifica se a celula extraida possui valor "1" e se utiliza da celula adjacente de cima para dar prosseguimento a função
                else if (cima[0, 0] == "3")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(cima[0, 1]), int.Parse(cima[0, 2]));
                    int num = ContarTracinhosAdjacentes();

                    if (num > 3)
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                }
                else if (diagonalCimaAtras[0, 0] == "1")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(diagonalCimaAtras[0, 1]), int.Parse(diagonalCimaAtras[0, 2]));
                    int num = ContarTracinhosAdjacentes();

                    if (num > 1)
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                }
                else if (diagonalCimaAtras[0, 0] == "2")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(diagonalCimaAtras[0, 1]), int.Parse(diagonalCimaAtras[0, 2]));
                    int num = ContarTracinhosAdjacentes();

                    if (num > 2)
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                }
                else if (diagonalCimaAtras[0, 0] == "3")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(diagonalCimaAtras[0, 1]), int.Parse(diagonalCimaAtras[0, 2]));
                    int num = ContarTracinhosAdjacentes();

                    if (num > 3)
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                }
                else if (diagonalCimaAtras[0, 0] == "4")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(diagonalCimaAtras[0, 1]), int.Parse(diagonalCimaAtras[0, 2]));
                    int num = ContarTracinhosAdjacentes();

                    if (num > 4)
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                }
                else if (diagonalCimaFrente[0, 0] == "3")
                {
                    LinhaseColunasCasaSelecionadaAoLado(int.Parse(diagonalCimaFrente[0, 1]), int.Parse(diagonalCimaFrente[0, 2]));
                    int num = ContarTracinhosAdjacentes();

                    if (num > 3)
                    {
                        campoMinado.Abrir(posicaoInical[0] + 1, posicaoInical[1] + 1);
                        preencherCampo();
                    }
                }
            } // Verifica se aciona ou não a função preencherCampo()

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    preencherCampo(); // Preenche a Matriz com os dados do campoMinado.Tabuleiro
                    posicaoInical[0] = i; // Pega a posição selecionada da Matriz 
                    posicaoInical[1] = j;

                    if (matriz[i, j] == "-") // Verifica se a matriz possui celulas não preenchidas
                    {
                        LinhaseColunasCasaSelecionada(i, j); // Preenche um Grupo de Arrays com as posições e valores das celular adjacentes
                    }
                }

            } // Acionar o preenchimento da Matriz.

            Console.WriteLine(campoMinado.Tabuleiro); // Mostra tabela preenchida na tela
            Console.WriteLine("JogoStatus: " + campoMinado.JogoStatus); // Chama Status 

        }
    }
}
