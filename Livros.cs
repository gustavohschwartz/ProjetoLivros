using static System.Runtime.InteropServices.JavaScript.JSType;

public class Livros
{
    public string Aluno { get; set; }
    public string Livro { get; set; }
    public string Data { get; set; }
   
}

public class Bibiliotecaria
{
    public string NomeBibliotecaria { get; set; }
    public string DataConclusao { get; set; }
}




internal class ListaLivros
{
    static Queue<Livros> filaLivros = new Queue<Livros>();
    static List<Livros> registroLivros = new List<Livros>();
    static List<Bibiliotecaria> registroConclusao = new List<Bibiliotecaria>();
    

    static void Main(string[] args)
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }
    static bool MainMenu()
    {
        Console.WriteLine($"<---------------------------->");
        Console.WriteLine($"Digite 1 para Incluir Solicitação:");
        Console.WriteLine($"Digite 2 para Concluir Solicitação:");
        Console.WriteLine($"Digite 3 para Listar Solicitações Pendentes:");
        Console.WriteLine($"Digite 4 para Listar Solicitações Concluidas:");
        Console.WriteLine($"Digite 5 para Sair");
        Console.WriteLine($"<---------------------------->");

        var linha = Console.ReadLine();
        if (linha == "1")
        {
            addSolicitacao();
            return true;
        }
        else if (linha == "2")
        {
            concluirSolicitacao();
            return true;
        }
        else if (linha == "3")
        {
            listarSolicitacaoPendente();
            return true;
        }
        else if (linha == "4")
        {
            listarSolicitacoesConcluidas();
            return true;
        }
        else if (linha == "5")
        {
            
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void concluirSolicitacao()
    {
        if (filaLivros.Count > 0)
        {
            Console.WriteLine($"Digite Nome da Bibliotecária: ");
            var nomeBibli = Console.ReadLine();
            Console.WriteLine("Digite a Data de Conclusão da Solicitação (**/**/****): ");
            var dataConcl = Console.ReadLine();

           Bibiliotecaria regConcl = new Bibiliotecaria
        {
            NomeBibliotecaria = nomeBibli,
            DataConclusao = dataConcl
        };
           

            Livros solicitacaoAtual = filaLivros.Dequeue();
            Console.WriteLine($"<---------------------------->");
            Console.WriteLine($"Finalizando solicitação de {solicitacaoAtual.Aluno} com o livro {solicitacaoAtual.Livro}");

            registroLivros.Add(solicitacaoAtual);
        }
        else
        {
            Console.WriteLine($"<---------------------------->");
            Console.WriteLine("Sem solicitações para Concluir!");
        }
    }

    public static void addSolicitacao()
    {
        Console.WriteLine($"<---------------------------->");
        Console.WriteLine($"Digite seu Nome");
        var nome = Console.ReadLine();
        Console.WriteLine($"Digite Nome do Livro: ");
        var livro = Console.ReadLine();
        Console.WriteLine("Digite a Data de Solicitação (**/**/****): ");
        var data = Console.ReadLine();

        Livros livros = new Livros
        {
            Aluno = nome,
            Livro = livro,
            Data = data
        };

        filaLivros.Enqueue(livros);
        Console.WriteLine($"Solicitação do livro {livro} de {nome} na data {data} adicionado à fila.");
    }

    public static void listarSolicitacaoPendente()
    {
        if (filaLivros.Count() > 0)
        {
            foreach (var livros in filaLivros)
            {
                Console.WriteLine($"<---------------------------->");
                Console.WriteLine($"Nome do Aluno:{livros.Aluno}");
                Console.WriteLine($"Livro:{livros.Livro}");
                Console.WriteLine($"Data Solicitação: {livros.Data}");
            }
        }
        else
        {
            Console.WriteLine("Não Há Solicitações Pendentes!");
        }
    }
    public static void listarSolicitacoesConcluidas()
    {
        if (registroLivros.Count() > 0 && registroConclusao.Count()>0) { 
            foreach (var livros in registroLivros)  
                foreach (var regConcl in  registroConclusao)

                {
                Console.WriteLine($"Solicitacao do aluno:{livros.Aluno}");
                Console.WriteLine($"Nome do Livro:{livros.Livro}");
                Console.WriteLine($"Data Solicitação: {livros.Data}");            
                Console.WriteLine($"Nome bibliotecária: {regConcl.NomeBibliotecaria}");      
                Console.WriteLine($"Data Conclusão: {regConcl.DataConclusao}");
                
            }
        }
        else
        {
            Console.WriteLine("Lista Vazia");
        }
    }
}