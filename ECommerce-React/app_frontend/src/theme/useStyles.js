import { createTheme, makeStyles } from "@material-ui/core";

const theme = createTheme();

const useStyles = makeStyles({
  containermt: {
    marginTop: 30,
  },
  card: {
    padding: 30,
  },
  avatar: {
    backgroundColor: "#0f80aa",
    width: 80,
    height: 80,
  },
  icon: {
    fontSize: 60,
  },
  form: {
    marginTop: 40,
    marginBottom: 10,
  },
  gridmb: {
    marginBottom: 20,
  },
  link: {
    fontSize: "1.1rem",
    fontFamily: "Roboto",
    lineHeight: 1.5,
    color: theme.palette.primary.main,
    textDecoration: "none",
    marginTop: 8,
  },
  appBar: {
    paddingTop: 8,
    paddingBottom: 8,
  },
  grow: {
    flexGrow: 0 /*por abajo de 960px, que no tome el espacio */,
    [theme.breakpoints.up("md")]: {
      flexGrow: 1 /*si esta por arriba de 960px, que tome el espacio el logo */,
    },
  },
  mr: {
    marginRight: 3,
  },
  linkAppBarLogo: {
    display: "inline-flex",
    alignItems: "center",
    color: "inherit",
    textDecoration: "none",
  },
  buttonIcon: {
    fontSize: 14,
    padding: 0,
  },
  linkAppBarDesktop: {
    display: "inline-flex",
    alignItems: "center",
    padding: "6px 16px",
    color: "inherit",
    textDecoration: "none",
  },
  list: {
    width: 250,
  },
  listItem: {
    padding: 0,
  },
  linkAppBarMobile: {
    display: "inline-flex",
    alignItems: "center",
    width: "100%",
    padding: "8px 16px",
    color: "inherit",
    textDecoration: "none",
  },
  listItemIcon: {
    minWidth: 35,
    color: "inherit",
  },
  sectionDesktop: {
    /*si esta por arriba de 960 px, muestra el boton de login, si es menor lo oculta */
    display: "none" /*aca con esto lo oculta si esta por abajo de 960px */,
    [theme.breakpoints.up("md")]: {
      /*si esta por arriba de 960 px lo muestra */ display: "flex",
    },
  },
  sectionMobile: {
    display: "flex" /*si esta por abajo de 960px lo muestra */,
    flexGrow: 1,
    [theme.breakpoints.up("md")]: {
      /*si esta por arriba de 960 px lo oculta */ display: "none",
    },
  },
});

export default useStyles;
