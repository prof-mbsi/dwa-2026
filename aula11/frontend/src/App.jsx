import { useEffect, useState } from "react";

function App() {
  const [produtos, setProdutos] = useState([]);

  const [nome, setNome] = useState("");

  const [preco, setPreco] = useState("");

  useEffect(() => {
    buscarProdutos();
  }, []);

  async function buscarProdutos() {
    const response = await fetch("http://localhost:5063/api/produtos");

    const data = await response.json();

    setProdutos(data);
  }

  async function cadastrarProduto() {
    const produto = {
      nome,
      preco: Number(preco),
    };

    await fetch("http://localhost:5063/api/produtos", {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },

      body: JSON.stringify(produto),
    });

    buscarProdutos();

    setNome("");

    setPreco("");
  }

  return (
    <div>
      <h1>Produtos</h1>

      <input
        type="text"
        placeholder="Nome"
        value={nome}
        onChange={(e) => setNome(e.target.value)}
      />

      <br />
      <br />

      <input
        type="number"
        placeholder="Preço"
        value={preco}
        onChange={(e) => setPreco(e.target.value)}
      />

      <br />
      <br />

      <button onClick={cadastrarProduto}>Cadastrar</button>

      <hr />

      {produtos.length === 0 ? (
        <p>Nenhum produto encontrado</p>
      ) : (
        produtos.map((p) => (
          <div key={p.id}>
            <h3>{p.nome}</h3>

            <p>R$ {p.preco}</p>

            <hr />
          </div>
        ))
      )}
    </div>
  );
}

export default App;
