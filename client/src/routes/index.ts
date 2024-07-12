import { ReactElement } from "react";
import { HomeLayout, AdminLayout, EmptyLayout } from "../layouts";

import * as Landing from "../pages/LandingPage";

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
  { path: "/introduction", page: Landing.LandingPage, layout: EmptyLayout },
];

export default routes;
