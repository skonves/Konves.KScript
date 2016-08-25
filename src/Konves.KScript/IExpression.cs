using System.Collections.Generic;

namespace Konves.KScript
{
	public interface IExpression
	{
		bool Evaluate(IDictionary<string, object> state);
	}
}
