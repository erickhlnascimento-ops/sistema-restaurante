-- Criar banco
CREATE DATABASE RestauranteDB;
GO

USE RestauranteDB;
GO

-- ========================
-- TABELA USUARIO
-- ========================
CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(100) NOT NULL,
    email NVARCHAR(150) NOT NULL UNIQUE,
    senha NVARCHAR(255) NULL,
    provider NVARCHAR(50) NOT NULL DEFAULT 'local', -- local ou google
    provider_id NVARCHAR(255) NULL,
    data_cadastro DATETIME DEFAULT GETDATE()
);

-- ========================
-- TABELA MESA
-- ========================
CREATE TABLE Mesa (
    id_mesa INT IDENTITY(1,1) PRIMARY KEY,
    numero_mesa INT NOT NULL,
    token_qr NVARCHAR(100) NOT NULL UNIQUE,
    ativa BIT DEFAULT 1
);

-- ========================
-- TABELA CATEGORIA
-- ========================
CREATE TABLE Categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(100) NOT NULL
);

-- ========================
-- TABELA PRODUTO
-- ========================
CREATE TABLE Produto (
    id_produto INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(150) NOT NULL,
    descricao NVARCHAR(500),
    preco DECIMAL(10,2) NOT NULL,
    imagem_url NVARCHAR(500),
    id_categoria INT NOT NULL,
    ativo BIT DEFAULT 1,

    CONSTRAINT FK_Produto_Categoria
    FOREIGN KEY (id_categoria)
    REFERENCES Categoria(id_categoria)
);

-- ========================
-- TABELA PEDIDO
-- ========================
CREATE TABLE Pedido (
    id_pedido INT IDENTITY(1,1) PRIMARY KEY,
    id_mesa INT NOT NULL,
    data_pedido DATETIME DEFAULT GETDATE(),
    status NVARCHAR(50) NOT NULL DEFAULT 'aberto',
    valor_total DECIMAL(10,2) DEFAULT 0,

    CONSTRAINT FK_Pedido_Mesa
    FOREIGN KEY (id_mesa)
    REFERENCES Mesa(id_mesa),

    CONSTRAINT CK_Status_Pedido
    CHECK (status IN ('aberto', 'em preparo', 'pronto', 'finalizado'))
);

-- ========================
-- TABELA ITEM PEDIDO
-- ========================
CREATE TABLE ItemPedido (
    id_item INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT NOT NULL,
    id_produto INT NOT NULL,
    quantidade INT NOT NULL CHECK (quantidade > 0),
    preco_unitario DECIMAL(10,2) NOT NULL,
    nome_cliente NVARCHAR(100) NOT NULL,
    observacao NVARCHAR(300),

    CONSTRAINT FK_ItemPedido_Pedido
    FOREIGN KEY (id_pedido)
    REFERENCES Pedido(id_pedido),

    CONSTRAINT FK_ItemPedido_Produto
    FOREIGN KEY (id_produto)
    REFERENCES Produto(id_produto)
);