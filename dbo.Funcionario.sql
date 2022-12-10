CREATE TABLE [dbo].[Funcionario]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(100) NOT NULL, 
    [Matricula] NVARCHAR(50) NOT NULL, 
    [AreaAtuacao] INT NOT NULL, 
    [Cargo] INT NOT NULL, 
    [SalarioBruto] DECIMAL NOT NULL, 
    [DataAdmissao] DATETIME NOT NULL, 
    [DataCadastro] DATETIME NOT NULL
)
