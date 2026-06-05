namespace BibliotecaConsole;

public class Program
{
    public static void Main()
    {
        //Criar listas de cada tipo: Clint, Livros e Loan(emprestimo)
        List<Book> bookList = new List<Book>();
        List<Client> clientList = new List<Client>();
        List<Loan> loanList = new List<Loan>();
        
        //Menu console (UI hihi)
        Console.WriteLine("=== SISTEMA BIBLIOTECÁRIO ===");
        Console.WriteLine("1 - Adicionar Livro");
        Console.WriteLine("2 - Listar Livros");
        Console.WriteLine("3 - Cadastrar Cliente");
        Console.WriteLine("4 - Listar Clientes");
        Console.WriteLine("5 - Realizar empréstimo");
        Console.WriteLine("6 - Ver empréstimos do cliente");
        Console.WriteLine("0 - Sair");
        
        //start na bomba
        bool systemRunning = true;


        while (systemRunning)
        {
            string userEnter = Console.ReadLine();

            switch (userEnter)
            {
                //Adiciona livro(book) a lista de livros(bookList)
                case "1":
                    Console.WriteLine("Nome do Livro: ");
                    string BookEnter = Console.ReadLine();
                    Console.WriteLine("Nome do Autor: ");
                    string AuthorEnter = Console.ReadLine();

                    //verifica entrada nulas e vazias
                    if (!string.IsNullOrEmpty(BookEnter) && !string.IsNullOrEmpty(AuthorEnter))
                    {
                        //cria novo livro(objeto) do tipo Book(class)
                        Book book = new Book();
                        //adiciona caracteriscas ao livro criado
                        book.BookName = BookEnter;
                        book.AuthorBook = AuthorEnter;
                        //adiciona livro a lista
                        bookList.Add(book);
                        Console.WriteLine("Seu Livro foi adicionado");
                    }
                    else
                    {
                        Console.WriteLine("Nome e Autor não pode estar vazio!");
                    }
                    break;
                
                //Exibe lista de livros
                case "2":
                    Console.WriteLine("=== Livros Cadastrados ===");
                    //percorre lista de livros por indice e exibe numerado(count)
                    for (int i = 0; i < bookList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {bookList[i].BookName} - {bookList[i].AuthorBook}");
                    }
                    break;
                
                //Cadastra cliente
                case "3":
                    Console.WriteLine("Nome do cliente: ");
                    string clientNameEnter = Console.ReadLine();
                    Console.WriteLine("E-mail do cliente: ");
                    string clientEmailEnter = Console.ReadLine();
                    //verifica entradas nulas e vazias
                    if (!string.IsNullOrEmpty(clientNameEnter) && !string.IsNullOrEmpty(clientEmailEnter))
                    {
                        //cria novo client(objeto) do tipo Client(class)
                        Client client = new Client();
                        //adiciona caracteriscas ao cliente criado
                        client.Name = clientNameEnter;
                        client.Email = clientEmailEnter;
                        //Adiciona a lista de clientes
                        clientList.Add(client);
                        Console.WriteLine("Cliente Adicionado!");
                    }
                    else
                    {
                        Console.WriteLine("Nome e E-mail não pode estar vazio!");
                    }
                    break;

                //Exibe lista de Clientes(mesma logica de livros)
                case "4":
                    Console.WriteLine("=== Lista de Clientes Cadastrados ===");
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {clientList[i].Name} - {clientList[i].Email}");
                    }
                    break;

                //Relaciona classes (Client + Book)
                case "5":
                    Console.WriteLine("=== Realizar Emprestimo ===");
                    Console.WriteLine("Selecione Primeiro um Cliente Cadastrado");
                    //percorre lista de clientes por indice e mostra no console
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {clientList[i].Name}");
                    }
                    //Escolhe cliente da lista cliente para relacionar a livro da lista livros
                    string userLoanClient = Console.ReadLine();

                    //converte entrada tipo string para inteiro -1(indice 0)
                    int clientIndex = Convert.ToInt32(userLoanClient) - 1;
                    //armazena cliente selecionado
                    Client selectedClient = clientList[clientIndex];

                    //percorre lista de livros por indice e mostra no console
                    Console.WriteLine("Selecione Primeiro um Livro Cadastrado");
                    for (int i = 0; i < bookList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {bookList[i].BookName}");
                    }
                    //mesma logica de cliente
                    string userBookLoanChoise = Console.ReadLine();
                    int bookIndex = Convert.ToInt32(userBookLoanChoise) - 1;

                    //armazena livro selecionado
                    Book selectedBookClient = bookList[bookIndex];

                    //cria novo objeto loan(class Loan) relacionado de Clients e Books
                    Loan loan = new Loan();

                    //altera caracteriscas herdadas de outras class para 
                    loan.Client = selectedClient;
                    loan.Book = selectedBookClient;


                    //Confirma locacao do livro
                    Console.WriteLine($"Confirma que{loan.Client.Name} está pegando o livro {loan.Book.BookName}?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    string confirmChoise = Console.ReadLine();

                    if (confirmChoise == "1")
                    {
                        loanList.Add(loan);
                        Console.WriteLine($"Livro {loan.Book.BookName} emprestado para {loan.Client.Name}!");
                    }
                    else if (confirmChoise == "2")
                    {
                        Console.WriteLine("Operação Cancelada!");
                    }
                    else
                    {
                        Console.WriteLine("Erro!");
                    }
                    break;
                
                //Mosta lista de emprestimos registrados
                case "6":

                    Console.WriteLine("=== Empréstimos Realizados ===");

                    if (loanList.Count == 0)
                    {
                        Console.WriteLine("Nenhum empréstimo cadastrado.");
                    }
                    else
                    {
                        for (int i = 0; i < loanList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {loanList[i].Client.Name} → {loanList[i].Book.BookName}");
                        }
                    }
                    break;

                //desliga a bomba
                case "0":
                    Console.WriteLine("Sistema Encerrado!");
                    systemRunning = false;
                    break;

            }
        }


    }
}