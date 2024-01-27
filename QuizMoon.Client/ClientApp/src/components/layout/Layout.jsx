import React from 'react';
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

const Layout = (props) => {
  return (
    <FullScreen>
        <LeftPanelContainer>
          <LeftPanel/>
        </LeftPanelContainer>
      <RightPanelContainer>
        <RightPanel>
          {props.children}
        </RightPanel>
      </RightPanelContainer>
    </FullScreen>
  );
}

export default Layout;