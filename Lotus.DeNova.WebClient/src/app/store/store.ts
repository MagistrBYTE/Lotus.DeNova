import { Action, ThunkAction, configureStore } from '@reduxjs/toolkit'
import { notificationSlice } from 'src/shared/account';
import { layoutSlice } from 'src/shared/layout';

export function makeStore() 
{
  return configureStore(
    {
      reducer: 
      { 
        notification: notificationSlice.reducer,
        layout: layoutSlice.reducer  
      }
    })
}

export const store = makeStore();

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;

// Inferred type: {auth: AuthState, form: FormState, weather: WeatherState}
export type AppDispatch = typeof store.dispatch;

export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>