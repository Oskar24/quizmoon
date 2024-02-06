import React, { ReactNode } from "react";
import styled from "styled-components";



const Content = styled.div`
    margin: 20px;
`;

interface RightPanelProps{
    children: ReactNode;
}

const RightPanel: React.FC<RightPanelProps> = ({children}) => {
    return (
        <Content>
            {children}
        </Content>
    )
}

export default RightPanel;