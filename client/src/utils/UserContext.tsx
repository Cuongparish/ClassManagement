import React, { createContext, useContext, useState, ReactNode } from "react";

interface User {
  idUser: string;
  Email: string;
  Pw: string;
  FullName: string;
  DOB: string;
  Sex: string;
  Phone: string;
  StudentId: string;
}

interface UserContextProps {
  user: User | null;
  setUser: React.Dispatch<React.SetStateAction<User | null>>;
}

const UserContext = createContext<UserContextProps | undefined>(undefined);

export const UserProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<User | null>({
    idUser: "1",
    Email: "user@example.com",
    Pw: "password",
    FullName: "John Doe",
    DOB: "1990-01-01",
    Sex: "Male",
    Phone: "123-456-7890",
    StudentId: "S123456",
  });

  return (
    <UserContext.Provider value={{ user, setUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = (): UserContextProps => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useUser must be used within a UserProvider");
  }
  return context;
};
