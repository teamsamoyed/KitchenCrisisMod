/*--------------------------------------------------------------------------------*
  Copyright (C)Nintendo All rights reserved.

  These coded instructions, statements, and computer programs contain proprietary
  information of Nintendo and/or its licensed developers and are protected by
  national and international copyright laws. They may not be disclosed to third
  parties or copied or duplicated in any form, in whole or in part, without the
  prior written consent of Nintendo.

  The content herein is highly confidential and should be handled accordingly.
 *--------------------------------------------------------------------------------*/
#if defined( NN_GFX_VERTEX_SHADER )
    #define VARYING_QUALIFIER out
    #define VARYING_INSTANCE Out
#endif

#if defined( NN_GFX_PIXEL_SHADER )
    #define VARYING_QUALIFIER in
    #define VARYING_INSTANCE In
#endif

precision highp float;
