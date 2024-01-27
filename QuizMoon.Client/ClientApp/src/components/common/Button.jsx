import React from 'react';
import styled from 'styled-components';
import * as COLORS from '../../constants/Colors';

function GetButtonHeight(size) {
  switch (size) {
    case 'small':
      return 40;
    case 'medium':
      return 40;
    case 'large':
      return 50;
    default:
      return 40;
  }
}

function GetButtonWidth(size) {
  switch (size) {
    case 'small':
      return 80;
    case 'medium':
      return 120;
    case 'large':
      return 160;
    default:
      return 120;
  }
}

const StyledButton = styled.button`
  position: relative;
  background: transparent;
  color: inherit;
  border: none;
  height: ${(props) => GetButtonHeight(props.size)}px;
  width: ${(props) => GetButtonWidth(props.size)}px;
  margin: 5px;
  transition: all 0.15s ease;

  &:after {
    content: '';
    position: absolute;
    bottom: 10%;
    left: 50%;
    transform: translateX(-50%);
    width: 0%;
    height: 1px;
    background-color: ${(props) => props.$variant === 'primary' ? COLORS.MAIN_THEME_1 : COLORS.MAIN_THEME_2};
    transition: all 0.15s ease;
  }

  &:hover:after {
    width: 30%;
  }

  &:hover{
    color: ${(props) => props.$variant === 'primary' ? COLORS.MAIN_THEME_1 : COLORS.MAIN_THEME_2};
  }
`;

const Button = ({ label, variant = 'secondary', size = 'medium', onClick }) => {
  return(
  <StyledButton onClick={onClick} $variant={variant} size={size} >
    {label}
  </StyledButton>
  );
};

export default Button;