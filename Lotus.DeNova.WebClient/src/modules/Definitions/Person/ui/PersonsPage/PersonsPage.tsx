import React from 'react';
import { TScreenType, useLayoutState } from 'src/shared/layout';
import { PageContainer } from 'src/ui/components/Layout';
import { PersonTable } from './components/PersonTable';
import { PersonList } from './components/PersonList';

export const PersonsPage: React.FC = () => 
{
  const isDesktop = useLayoutState().screenType === TScreenType.Desktop;

  return (
    <PageContainer>
      {isDesktop && <PersonTable/>}
      {!isDesktop && <PersonList/>}
    </PageContainer>
  );
};