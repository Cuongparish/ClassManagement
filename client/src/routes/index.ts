import { ReactElement } from "react";
import { EmptyLayout } from "../layouts";

import * as Authentication from "../pages/Authentication";

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
];

export default routes;
