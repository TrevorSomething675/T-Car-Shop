'use client'

import { Inter } from 'next/font/google';
import './global.css';
import './colors.css';
import '@/app/extensions/slider.css'
import store from '@/store/store';
const inter = Inter({ subsets: ["latin"] });

import React, { useEffect } from 'react';

const Layout = ({
  children,
}: {
  children: React.ReactNode
}) => {
  useEffect(() =>{
    store.checkAuth();
  });
  return (
    <html lang="en">
      <body className={inter.className}>{children}</body>
    </html>
  )
}

export default Layout;