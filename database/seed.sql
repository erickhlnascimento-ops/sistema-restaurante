USE RestauranteDB;
GO

---Inserindo Categorias---

INSERT INTO Categoria (nome) VALUES
('Entradas'),('Pratos Principais'),('Pizzas'),('Sobremesas'),('Bebidas'),('Vinhos');

---Inserindo Entradas---

INSERT INTO Produto (nome,descricao,preco,id_categoria,ativo) VALUES
('Bruschetta Tradicional', 'Pão italiano tostado com tomate, manjericão e azeite', 18.00, 1, 1),
('Carpaccio de Carne', 'Finas fatias de carne com parmesão, rúcula e molho especial', 32.00, 1, 1),
('Caprese', 'Tomate, mussarela de búfala e manjericão com azeite', 25.00, 1, 1);

---Inserindo Pratos Principais---

INSERT INTO Produto (nome,descricao,preco,id_categoria,ativo) VALUES
('Spaghetti Carbonara', 'Massa com molho cremoso de ovos, parmesão e pancetta', 38.00, 2, 1),
('Fettuccine Alfredo', 'Massa com molho cremoso de manteiga e queijo parmesão', 36.00, 2, 1),
('Lasanha à Bolonhesa', 'Camadas de massa com carne, molho de tomate e queijo gratinado', 42.00, 2, 1),
('Penne ao Molho Pesto', 'Massa com molho de manjericão, azeite e parmesão', 34.00, 2, 1),
('Ravioli de Queijo', 'Massa recheada com queijo ao molho de tomate caseiro', 40.00, 2, 1),
('Gnocchi ao Molho Sugo', 'Nhoque de batata ao molho de tomate caseiro com parmesão', 35.00, 2, 1),
('Spaghetti à Bolonhesa', 'Massa com molho de carne moída e tomate', 37.00, 2, 1),
('Fettuccine com Frango', 'Massa com tiras de frango ao molho cremoso', 39.00, 2, 1),
('Risoto de Funghi', 'Arroz arbóreo cremoso com cogumelos e parmesão', 44.00, 2, 1),
('Ravioli de Carne', 'Massa recheada com carne ao molho de tomate e ervas', 41.00, 2, 1);

---Inserindo Pizzas---

INSERT INTO Produto (nome,descricao,preco,id_categoria,ativo) VALUES
('Pizza Margherita', 'Molho de tomate, mussarela, manjericão e azeite', 45.00, 3, 1),
('Pizza Calabresa', 'Calabresa fatiada, cebola e mussarela', 48.00, 3, 1),
('Pizza Portuguesa', 'Presunto, ovos, cebola, ervilha e mussarela', 50.00, 3, 1),
('Pizza Quatro Queijos', 'Mussarela, parmesão, gorgonzola e provolone', 52.00, 3, 1),
('Pizza Frango com Catupiry', 'Frango desfiado com catupiry e mussarela', 49.00, 3, 1),
('Pizza Pepperoni', 'Pepperoni com mussarela e molho de tomate', 51.00, 3, 1),
('Pizza Bacon', 'Bacon crocante com mussarela e cebola', 50.00, 3, 1),
('Pizza Vegetariana', 'Legumes grelhados com mussarela e molho de tomate', 47.00, 3, 1);

---Inserindo Sobremesas---

INSERT INTO Produto (nome,descricao,preco,id_categoria,ativo) VALUES
('Tiramisù', 'Sobremesa italiana com café, mascarpone e cacau', 18.00, 4, 1),
('Panna Cotta', 'Creme italiano com calda de frutas vermelhas', 16.00, 4, 1),
('Cannoli', 'Massa crocante recheada com creme doce de ricota', 15.00, 4, 1),
('Torta de Limão Siciliano', 'Base crocante com creme de limão e cobertura suave', 17.00, 4, 1),
('Zabaglione', 'Creme italiano leve feito com gemas, açúcar e vinho doce', 19.00, 4, 1);

---Inserindo Bebidas---

INSERT INTO Produto (nome,descricao,preco,id_categoria,ativo) VALUES
('Refrigerante Coca-Cola Lata', 'Refrigerante Coca-Cola 350ml', 8.00, 5, 1),
('Refrigerante Guaraná Lata', 'Refrigerante Guaraná 350ml', 8.00, 5, 1),
('Refrigerante Fanta Lata', 'Refrigerante Fanta 350ml', 8.00, 5, 1),
('Água Mineral', 'Água sem gás 500ml', 5.00, 5, 1),
('Água com Gás', 'Água mineral com gás 500ml', 6.00, 5, 1),
('Suco de Laranja', 'Suco natural de laranja', 10.00, 5, 1),
('Suco de Limão', 'Suco natural de limão', 10.00, 5, 1),
('Suco de Maracujá', 'Suco natural de maracujá', 10.00, 5, 1),
('Chá Gelado de Limão', 'Chá preto gelado com limão', 9.00, 5, 1);

---Inserindo Vinhos---

INSERT INTO Produto (nome,descricao,preco,id_categoria,ativo) VALUES
('Vinho Tinto Suave', 'Vinho tinto leve e adocicado, ideal para iniciantes', 25.00, 5, 1),
('Vinho Tinto Seco', 'Vinho encorpado com notas de frutas vermelhas', 35.00, 5, 1),
('Vinho Branco Seco', 'Vinho branco refrescante com leve acidez', 30.00, 5, 1),
('Vinho Rosé', 'Vinho leve e frutado, servido gelado', 32.00, 5, 1);

---Cadastrando Mesas---

INSERT INTO Mesa (numero_mesa, token_qr, ativa)
VALUES
(1, 'c1f7a9e2-8b3d-4f6a-9c21-5e7d1a2b3c41', 1),
(2, 'a9d2c7f1-3e8b-4a6f-b921-7c5e2d1a4b62', 1),
(3, '5e3c1a9d-7b2f-4e8a-91c6-d2a7b3f4c583', 1),
(4, '8b1f2c7a-4d9e-46a3-8c51-1e7b2a9d6f94', 1),
(5, '2d7a1c9b-5e3f-4b8a-9c61-7a2e1d3f5b05', 1),
(6, '9a3e1b7c-2d4f-4c8a-b951-6f2a7d1e3c16', 1),
(7, '4c8a2d1f-7b3e-49a6-8c21-5d1a7e3f9b27', 1),
(8, '7e1c3a9d-5b2f-4a8c-91d6-3f7a2b1e4c38', 1),
(9, '3b7d1a2c-9e5f-4c8a-a621-1f3e7d2b5c49', 1),
(10, '6f2a1c9e-3b7d-4a8c-9e51-2d1f3a7b6c50', 1);

---Cadastrando Usuarios Teste---

INSERT INTO Usuario (nome, email, senha, tipo)
VALUES
('Admin', 'admin@restaurante.com', '123456', 'admin'),
('João', 'joao@email.com', '123456', 'cliente'),
('Maria', 'maria@email.com', '123456', 'cliente');


UPDATE Categoria
SET nome = 'Pizzas'
WHERE id_categoria = 3;

UPDATE Produto
SET id_categoria = 6
WHERE nome LIKE 'Vinho%';



SELECT *
FROM Categoria;


SELECT *
FROM Produto;

SELECT *
FROM Mesa;

SELECT *
FROM Usuario;