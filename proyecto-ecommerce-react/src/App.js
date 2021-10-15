import React, { useState } from "react";
import Perfil from "./componentes/Perfil";

function App() {
  const [nombre, setNombre] = useState("Joaquín");

  const eventoCajaTexto = (e) => {
    console.log(e);
    console.log(e.target.value);
    setNombre(e.target.value);
  };

  return (
    <div>
      <h1>{nombre}</h1>
      <input
        type="text"
        name="nombre"
        value={nombre}
        onChange={eventoCajaTexto}
      />

      <Perfil nombre={nombre}></Perfil>
    </div>
  );
}

export default App;
