'use client'

import { Inter } from 'next/font/google';
import './global.css';
import './colors.css';
import '@/app/extensions/slider.css'
import Store from "@/store/store";
import { createContext } from "react";

const inter = Inter({ subsets: ["latin"] });

interface StoreState {
    store: Store;
}

const store = new Store();
export const Context = createContext<StoreState>({
    store,
})

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode;}>) {
  return (
    <Context.Provider value={{
      store
    }}>
      <html lang="en">
        <body className={inter.className}>{children}</body>
      </html>
    </Context.Provider>
  );
}
