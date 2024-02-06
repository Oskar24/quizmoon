import React, { ReactNode } from 'react';
import styled from 'styled-components';
import LeftPanel from './LeftPanel';
import RightPanel from './RightPanel';
import * as COLORS from '../../constants/Colors';

const FullScreen = styled.div`
  background: ${COLORS.MAIN_BACKGROUND};
  width: 100%;
  min-height: 100%;
  padding: 0px;
  display: flex;
  flex-direction: row;
  `;

const LeftPanelContainer = styled.div`
  flex: 0 0 250px;
`;

const RightPanelContainer = styled.div`
  flex: 1 1 auto;
`;

interface LayoutProps {
  children: ReactNode;
}

const Layout: React.FC<LayoutProps> = ({children}) => {
  return (
    <FullScreen>
        <LeftPanelContainer>
          <LeftPanel/>
        </LeftPanelContainer>
      <RightPanelContainer>
        <RightPanel>
          {children}
        </RightPanel>
      </RightPanelContainer>
    </FullScreen>
  );
}

export default Layout;