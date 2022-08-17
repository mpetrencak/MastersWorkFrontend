import { useBlazor } from './blazor-react';

export function BlazorPage({
  title,
  incrementAmount,
  customObject,
  customCallback,
}) {
  const fragment = useBlazor('blazor-app', {
    title,
    incrementAmount,
    customObject,
    customCallback,
  });

  return fragment;
}
