import React from 'react';
import { useLayoutState, TScreenType } from 'src/app/layout';
import { PageContainer } from 'src/ui/components/Layout';
import { PersonList } from 'src/widgets/player-context/persons/PersonList';
import { PersonTable } from 'src/widgets/player-context/persons/PersonTable';

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