import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "./assets/vite.svg";
import heroImg from "./assets/hero.png";
import "./App.css";
import Mensagem from "./Mensagem";
import Saudacao from "./Saudacao";
import Produto from "./Produto";

function App() {
  const [contador, setContador] = useState(0);
  const [nome, setNome] = useState("");
  const [preco, setPreco] = useState("");

  return (
    <div>
      <h1>Olá React!</h1>
      <Mensagem />
      <Saudacao nome="Marlon"></Saudacao>
      <Saudacao nome="Dunga" />
      <Produto nome="Água" preco="3.5" />
      <h1>{contador}</h1>
      <h2>{contador % 2 === 0 ? "Par" : "Ímpar"}</h2>
      <button onClick={() => setContador(contador + 1)}>Incrementar</button>
      <br />
      <button onClick={() => setContador(contador - 1)}>Decrementar</button>
      <br />
      <button onClick={() => setContador(0)}>Reset</button>
      <br />
      <br />
      <h1>Cadastro de Produto</h1>
      <input
        type="text"
        placeholder="Nome do produto"
        onChange={(e) => setNome(e.target.value)}
      />
      <br />
      <br />
      <input
        type="number"
        step="0.1"
        placeholder="Preço"
        onChange={(e) => setPreco(e.target.value)}
      />
      <br />
      <br />
      <Produto nome={nome} preco={preco} />
    </div>
  );
}

export default App;



=LET(inicio; 'Config Grade Horária'!$E$2; fim; 'Config Grade Horária'!$F$2;
     IFERROR(
        XLOOKUP("X";
              INDEX(Planejamento!M:M; inicio):INDEX(Planejamento!M:M; fim);
              INDEX(Planejamento!$H:$H; inicio):INDEX(Planejamento!$H:$H; fim));
        XLOOKUP("O";
              INDEX(Planejamento!M:M; inicio):INDEX(Planejamento!M:M; fim);
              INDEX(Planejamento!$H:$H; inicio):INDEX(Planejamento!$H:$H; fim);
              "")
     )
    )