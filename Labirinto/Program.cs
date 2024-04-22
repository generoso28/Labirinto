using System.Collections.Generic;
using System.Reflection.Metadata;

class Labirinto
{
    private const int limit = 15;


    static void mostrarLabirinto(char[,] array, int l, int c)
    {
        for (int i = 0; i < l; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < c; j++)
            {
                Console.Write($" {array[i, j]} ");
            }
        }
        Console.WriteLine();
    }


    static void criaLabirinto(char[,] meuLab)
    {
        Random random = new Random();
        for (int i = 0; i < limit; i++)
        {
            for (int j = 0; j < limit; j++)
            {
                meuLab[i, j] = random.Next(4) == 1 ? '|' : ' ';
            }
        }


        for (int i = 0; i < limit; i++)
        {
            meuLab[0, i] = '*';
            meuLab[limit - 1, i] = '*';
            meuLab[i, 0] = '*';
            meuLab[i, limit - 1] = '*';
        }


        int x = random.Next(limit);
        int y = random.Next(limit);
        meuLab[x, y] = 'Q';
    }
    static void buscarQueijo(char[,] meuLab, int i, int j)
    {
        Stack<int> pilha = new Stack<int>();

        do
        {
            meuLab[i, j] = '$';
            if (meuLab[i + 1, j] == 'Q')
            {
                Console.WriteLine("Queijo encontrado!");
                break;
            }
            else if (meuLab[i - 1, j] == 'Q')
            {
                Console.WriteLine("Queijo encontrado!");
                break;
            }
            else if (meuLab[i, j - 1] == 'Q')
            {
                Console.WriteLine("Queijo encontrado!");
                break;
            }
            else if (meuLab[i, j + 1] == 'Q')
            {
                Console.WriteLine("Queijo encontrado!");
                break;
            }
            else if (meuLab[i, j + 1] == ' ')
            {
                pilha.Push(i);
                pilha.Push(j);
                j++;
            }
            else if (meuLab[i + 1, j] == ' ')
            {
                pilha.Push(i);
                pilha.Push(j);
                i++;
            }
            else if (meuLab[i, j - 1] == ' ')
            {
                pilha.Push(i);
                pilha.Push(j);
                j--;
            }
            else if (meuLab[i - 1, j] == ' ')
            {
                pilha.Push(i);
                pilha.Push(j);
                i--;
            }
            else if (pilha.Count > 0)
            {
                j = pilha.Pop();
                i = pilha.Pop();
            }
            else
            {
                Console.WriteLine("Não há caminho!");
                break;
            }
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            mostrarLabirinto(meuLab, limit, limit);
        } while (meuLab[i, j] != 'Q');
    }
    static void Main(String[] args)
    {
        char[,] labirinto = new char[limit, limit];
        criaLabirinto(labirinto);
        mostrarLabirinto(labirinto, limit, limit);
        buscarQueijo(labirinto, 1, 1);
        Console.ReadKey();
    }
}

