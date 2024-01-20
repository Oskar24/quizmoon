import React from 'react';
import Header from './Header';
import styled from 'styled-components';
import LeftPanel from './LeftPanel';
import RightPanel from './RightPanel';
import * as COLORS from '../../constants/Colors';

const FullScreen = styled.div`
  background: ${COLORS.MAIN_BACKGROUND};
  height: 100%;
  width: 100%;
  padding: 0px;
  display: flex;
  `;

const LeftPanelContainer = styled.div`
  width: 250px;
  background-color: red;
`;

const RightPanelContainer = styled.div`
  flex-grow: 1;
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