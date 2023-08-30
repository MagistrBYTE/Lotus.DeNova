import React, { CSSProperties, useState } from 'react';
import { IconButton, Popover, SxProps, Typography } from '@mui/material';
import { IInformationData } from 'src/ui/types/InformationData';
import HelpOutlineIcon from '@mui/icons-material/HelpOutline';

export interface ILabelProps extends IInformationData
{
  /**
   * Надпись
   */
  label?: React.ReactNode;

  /**
   * Параметры надпись
   */
  labelProps?: SxProps;

  /**
   * Дочерние компоненты
   */
  children?: React.ReactNode;

  /**
   * 100% ширина
   */
  fullWidth?:boolean;
}

export const Label:React.FC<ILabelProps> = ({textInfo, textInfoKey, label, labelProps, children, fullWidth}:ILabelProps) => 
{
  const [anchorElemInfo, setAnchorElemInfo] = React.useState<HTMLButtonElement|null>(null);
  const [openInfo, setOpenInfo] = useState<boolean>(false);

  const handleOpenInfo = (event: React.MouseEvent<HTMLButtonElement>) => 
  {
    setOpenInfo(true);
    setAnchorElemInfo(event.currentTarget);
  };

  const handleCloseInfo = () => 
  {
    setOpenInfo(false);
    setAnchorElemInfo(null);
  };

  const cssProps:CSSProperties = fullWidth ? 
    {
      display: 'flex', 
      flexDirection: 'row', 
      justifyContent: 'flex-start',
      alignItems: 'center',
      width: '100%' 
    } : 
    {display: 'flex', 
      flexDirection: 'row', 
      justifyContent: 'flex-start',
      alignItems: 'center'
    }

  if(textInfo && (label || children))
  {
    return (
      <div style={cssProps}>
        <IconButton onClick={handleOpenInfo}>
          <HelpOutlineIcon />
        </IconButton>
        <Popover
          open={openInfo}
          anchorEl={anchorElemInfo}
          onClose={handleCloseInfo}
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'right'
          }}
        >
          <Typography sx={{ p: 1 }}>{textInfo}</Typography>
        </Popover>
        {label && <Typography sx={labelProps}>{label}</Typography>}
        {children}
      </div>
    )
  }

  if(label)
  {
    return (
      <div style={cssProps}>
        {<Typography sx={labelProps}>{label}</Typography>}
        {children}
      </div>
    )
  }

  return <>{children}</>;
}