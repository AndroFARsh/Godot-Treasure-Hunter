using System;

namespace Code.Infrastructure.Randoms
{
	public class SimpleRandomService : IRandomService
  {
	  public float Range(float inclusiveMin, float exclusiveMax)
	  {
		  double range = inclusiveMin - exclusiveMax;
		  double sample = Random.Shared.NextDouble();
		  double scaled = (sample * range) + inclusiveMin;
		  return (float) scaled;
	  }

	  public int Range(int inclusiveMin, int exclusiveMax) => 
			Random.Shared.Next(inclusiveMin, exclusiveMax);
  }
}