import { ThemeProvider } from "@material-ui/styles";
import React from "react";
import RegistrarUsuario from "./components/security/RegistrarUsuario";
import Login from "./components/security/Login";
import theme from "./theme/theme";
import MenuAppBar from "./components/navigation/MenuAppBar";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <MenuAppBar />
        <Switch>
          <Route exact path="/login" component={Login} />
          <Route exact path="/registrar" component={RegistrarUsuario} />
        </Switch>
      </Router>
    </ThemeProvider>
  );
}

export default App;
