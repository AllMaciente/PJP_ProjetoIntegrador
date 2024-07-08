Sim, é possível criar uma nova lista de objetos de uma classe a partir de outra lista, filtrando com base em um atributo específico. Vou te mostrar um exemplo de como fazer isso em C# utilizando Linq.

Suponha que você tem uma classe chamada `Pessoa`:

```csharp
public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cidade { get; set; }
}
```

E você tem uma lista de pessoas chamada `listaPessoas`:

```csharp
List<Pessoa> listaPessoas = new List<Pessoa>
{
    new Pessoa { Nome = "João", Idade = 30, Cidade = "São Paulo" },
    new Pessoa { Nome = "Maria", Idade = 25, Cidade = "Rio de Janeiro" },
    new Pessoa { Nome = "Pedro", Idade = 40, Cidade = "Belo Horizonte" },
    new Pessoa { Nome = "Ana", Idade = 22, Cidade = "São Paulo" }
};
```

Para criar uma nova lista filtrando pessoas com base na cidade, por exemplo, você pode usar Linq da seguinte maneira:

```csharp
using System.Linq;

// Filtrar pessoas que moram em São Paulo
List<Pessoa> pessoasEmSaoPaulo = listaPessoas.Where(p => p.Cidade == "São Paulo").ToList();
```

Neste exemplo, a nova lista `pessoasEmSaoPaulo` conterá apenas as pessoas cujo atributo `Cidade` seja "São Paulo".

Se você quiser filtrar por outro atributo, como a idade, basta ajustar a condição dentro do método `Where`:

```csharp
// Filtrar pessoas com idade maior que 25
List<Pessoa> pessoasComMaisDe25Anos = listaPessoas.Where(p => p.Idade > 25).ToList();
```

Assim, a lista `pessoasComMaisDe25Anos` conterá apenas as pessoas com mais de 25 anos de idade.

Esse é um exemplo básico de como filtrar uma lista de objetos em C# utilizando Linq. Você pode criar filtros mais complexos combinando várias condições, se necessário.



---
Claro! Vamos adicionar um botão para limpar os filtros e outro para fazer um filtro baseado na coluna "Livro". 

### Passo a Passo

1. Adicione dois novos botões: um para limpar os filtros e outro para filtrar pela coluna "Livro".
2. Crie um campo adicional no DataTable para armazenar os dados dos livros.
3. Adicione o evento `Click` para o botão de limpar os filtros e o botão de filtrar pela coluna "Livro".

### Código de Exemplo Atualizado

```csharp
using System;
using System.Data;
using System.Windows.Forms;

public class MyForm : Form
{
    private DataGridView dataGridView;
    private DataTable dataTable;
    private TextBox filterTextBox;
    private Button filterButton;
    private Button clearFilterButton;
    private Button filterByBookButton;
    private TextBox bookFilterTextBox;

    public MyForm()
    {
        dataGridView = new DataGridView { Dock = DockStyle.Top, Height = 200 };
        filterTextBox = new TextBox { Dock = DockStyle.Top };
        filterButton = new Button { Text = "Filtrar por Nome", Dock = DockStyle.Top };
        clearFilterButton = new Button { Text = "Limpar Filtros", Dock = DockStyle.Top };
        bookFilterTextBox = new TextBox { Dock = DockStyle.Top };
        filterByBookButton = new Button { Text = "Filtrar por Livro", Dock = DockStyle.Top };

        filterButton.Click += FilterButton_Click;
        clearFilterButton.Click += ClearFilterButton_Click;
        filterByBookButton.Click += FilterByBookButton_Click;

        this.Controls.Add(dataGridView);
        this.Controls.Add(filterTextBox);
        this.Controls.Add(filterButton);
        this.Controls.Add(clearFilterButton);
        this.Controls.Add(bookFilterTextBox);
        this.Controls.Add(filterByBookButton);

        LoadData();
    }

    private void LoadData()
    {
        dataTable = new DataTable();
        dataTable.Columns.Add("Nome", typeof(string));
        dataTable.Columns.Add("Idade", typeof(int));
        dataTable.Columns.Add("Livro", typeof(string));

        // Adiciona algumas linhas para teste
        dataTable.Rows.Add("João", 25, "Livro A");
        dataTable.Rows.Add("Maria", 30, "Livro B");
        dataTable.Rows.Add("Pedro", 28, "Livro A");
        dataTable.Rows.Add("Ana", 35, "Livro C");

        dataGridView.DataSource = dataTable;
    }

    private void FilterButton_Click(object sender, EventArgs e)
    {
        string filterExpression = $"Nome = '{filterTextBox.Text}'";
        dataTable.DefaultView.RowFilter = filterExpression;
    }

    private void ClearFilterButton_Click(object sender, EventArgs e)
    {
        dataTable.DefaultView.RowFilter = string.Empty;
    }

    private void FilterByBookButton_Click(object sender, EventArgs e)
    {
        string filterExpression = $"Livro = '{bookFilterTextBox.Text}'";
        dataTable.DefaultView.RowFilter = filterExpression;
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MyForm());
    }
}
```

### Explicação

1. **Adição de Novos Botões e TextBox**:
    - Adicionamos dois novos botões (`clearFilterButton` e `filterByBookButton`) e um `TextBox` (`bookFilterTextBox`) para inserir o nome do livro que queremos filtrar.

2. **Eventos dos Botões**:
    - `FilterButton_Click`: Filtra as linhas com base no valor da coluna "Nome".
    - `ClearFilterButton_Click`: Limpa qualquer filtro aplicado ao DataTable.
    - `FilterByBookButton_Click`: Filtra as linhas com base no valor da coluna "Livro".

3. **Atualização do DataTable**:
    - Adicionamos uma nova coluna "Livro" ao DataTable e populamos com alguns dados de exemplo.

Com essa implementação, você pode facilmente filtrar os dados no DataGridView com base no nome ou no livro, além de ter a opção de limpar todos os filtros aplicados.
