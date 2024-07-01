# DB
## Criar DB
```sql
CREATE DATABASE bibliotechDB
```

## Criar tabelas
```sql
ERRO
```

## código para conectar no BD 

```c#
public static void InitConexao(){
            string info = "server=localhost;database=bibliotechDB;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Não deu, foi mal");
            }
        }
        public static void CloseConexao() {
            conexao.Close();
        }
```