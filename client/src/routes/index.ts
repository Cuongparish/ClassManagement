import { ReactElement } from "react";
import { EmptyLayout, HomeLayout, ClassLayout } from "../layouts";

import * as Authentication from "../pages/Authentication";
import * as Home from "../pages/Home";
import * as Class from "../pages/Class";

interface LayoutProp {
  children: React.ReactNode | React.ReactElement<unknown>;
}

interface RouteItem {
  path: string;
  page: () => ReactElement;
  // eslint-disable-next-line no-empty-pattern
  layout: ({}: LayoutProp) => ReactElement;
  // role?: Role;
}

const routes: RouteItem[] = [
  { path: "/introduction", page: Authentication.LandingPage, layout: EmptyLayout },
  { path: "/login", page: Authentication.LoginPage, layout: EmptyLayout },
  { path: "/signup", page: Authentication.SignupPage, layout: EmptyLayout },

  {path: "/home", page: Home.HomePage, layout: HomeLayout},
  {path: "/profile", page: Home.ProfilePage, layout: HomeLayout},

  {path: "/class", page: Class.ClassPage, layout: ClassLayout},
];

export default routes;
