import React, { useEffect, useState } from "react";
import axios from "axios";

export default function Perfil({ nombre }) {
  //   useEffect(() => {
  //     document.title = nombre;
  //   }, [nombre]); /*cada vez que cambie el valor de nombre,
  //   se actualiza el titulo del documento, eso es lo que significa ingresar
  //   una propiedad entre las llaves */

  const [paises, setPaises] = useState([]);
  const [status, setStatus] = useState(false);

  useEffect(() => {
    axios
      .get("https://jsonplaceholder.typicode.com/comments")
      .then((resultado) => {})
      .catch((error) => {
        setStatus(true);
      });
  }, []);

  if (status) {
    return (
      <ul>
        {paises.map((pais, indice) => (
          <li key={indice}> {pais}</li>
        ))}
      </ul>
    );
  } else {
    return <h1>Esta cargandos los valores del api</h1>;
  }
}
